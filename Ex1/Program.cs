using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Ex1
{
    internal class Program
    {

        /* 
        * As mensagens a serem impressas na interação com o usuário.
        * Cada mensagem representa uma propriedade da classe Cliente.
        */
        private static readonly string[] messages = 
            {
                "Nome do Cliente:",
                "CPF:",
                "Data de Nascimento:",
                "Renda Mensal:",
                "Estado Civil:",
                "Dependentes:"
        };


        /* 
         * As ações a serem feitas na interação com o usuário.
         * Cada ação é responsável por pré-processar a linha de entrada lida
         * e chamar os métodos Set da propriedade a qual está associada.
         */
        private static readonly Action<Cliente, string>[] actions =
            {
                // Set Nome
                (c, line) => {c.Nome = line.Trim();},

                // Set CPF
                (c, line) => { c.Cpf = ulong.Parse(line); },

                // Set Data de Nascimento
                (c, line) =>
                {
                    c.DataDeNascimento = DateTime.ParseExact(line, "d", DateTimeFormatInfo.InvariantInfo);
                },

                // Set Renda Mensal
                (c, line) => {c.RendaMensal = Cliente.TipoRendaMensal.Parse(line); },

                // Set Estado Civil
                (c, line) => {c.EstadoCivil = Enum.Parse<TipoEstadoCivil>(line.Trim(), true);},

                // Set Dependentes
                (c, line) => {c.Dependentes = int.Parse(line);}
        };



        // Evitar Warning do Compilador
#pragma warning disable IDE0060
        internal static void Main(string[] args)
        {
            Cliente c = new();

            // Variável temporária, cada elemento é um campo do cliente
            string[] tempClient = new string[6];

            // Marca quais campos já foram aceitos
            bool[] done = new bool[6];

            // Enquanto existir pelo menos um campo não válido
            do
            {
                // Ler entrada para todos campos não aceitos
                for (int i = 0; i < done.Length; i++)
                {
                    if (!done[i])
                        GetInput(tempClient, i);
                }

                //// Verificar as entradas passadas pros campos ainda não aceitos
                //for (int i = 0; i < done.Length; i++)
                //{
                //    if (!done[i])
                //        Check(c, tempClient, done, i);
                //}

                // Verificar as entradas passadas pros campos ainda não aceitos - paralelamente
                // As mensagens de erro podem sair em uma ordem diferente da leitura dos campos
                Parallel.For(0, done.Length,
                   index =>
                   {
                       if (!done[index])
                           Check(c, tempClient, done, index);
                   });

            } while (done.Any(x => !x));

            Console.WriteLine(c);
        }

        private static void GetInput(in string[] tempClient, int index)
        {
            // Escreve qual campo está sendo solicitado, baseado na variável @messages
            Console.WriteLine(messages[index]);

            // Lê linha da entrada
            var linha = Console.ReadLine();

            // Armazena entrada em uma variável temporária
            tempClient[index] = linha;
        }

        // Verifica se entrada passada é válida
        private static void Check(in Cliente c, in string[] inputs, in bool[] done, int index)
        {
            try
            {
                // Invoca a ação associada ao campo corrente 
                actions[index](c, inputs[index]);

                // Se a entrada for válida, o campo é marcado como aceito
                done[index] = true;
            }
            catch (Cliente.InvalidClientException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e) 
            when (e is OverflowException || e is FormatException
            || e is ArgumentOutOfRangeException || e is InvalidEstadoCivilException
            || e is FormatException || e is ArgumentException)
            {
                Console.WriteLine(
                    Cliente.InvalidClientException
                    .MakeMessage(messages[index].Remove(messages[index].Length - 1), inputs[index], e.Message));
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: Algo inesperado ocorreu.\n{0}", e);
            }
        }

        /* Exceção lançada quando o usuário informa um Estado Civil inválido.
         * Isto é, diferente de C, V, S e D.
         */
        private class InvalidEstadoCivilException : Exception
        {
            public InvalidEstadoCivilException(string message)
            : base(message)
            { }
        }
    }
}