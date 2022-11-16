using System;
using System.Linq;

namespace Ex7
{
    internal class Program
    {

        internal static void Main(string[] args)
        { 
            Cliente c = new();
            string line;

            /* 
             * As mensagens a serem impressas na interação com o usuário.
             * Cada mensagem representa uma propriedade da classe Cliente.
             */
            string[] messages = { 
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
            Action<string>[] actions =
            {
                // Set Nome
                line => {c.Nome = line.Trim();},

                // Set CPF
                line => { c.Cpf = ulong.Parse(line); },

                // Set Data de Nascimento
                line =>
                {
                    var data = line.Split('/').Select(Int32.Parse).Reverse();
                    c.DataDeNascimento = new DateTime(data.First(), data.ElementAt(1), data.Last());
                },

                // Set Renda Mensal
                line => {c.RendaMensal = float.Parse(line); },

                // Set Estado Civil
                line =>
                {
                    line = line.Trim();
                    if(line.Length != 1)
                    {
                        throw new InvalidEstadoCivilException("Estado Civil deve conter apenas um caracter!");
                    } else
                    {
                        c.EstadoCivil = 
                            Char.ToUpper(line[0]) switch
                            {
                                'C' => Cliente.TipoEstadoCivil.CASADO,
                                'S' => Cliente.TipoEstadoCivil.SOLTEIRO, 
                                'V' => Cliente.TipoEstadoCivil.VIUVO, 
                                'D' => Cliente.TipoEstadoCivil.DIVORCIADO, 
                                _ => throw new InvalidEstadoCivilException("Entrada Inválida. Estado Civil deve ser {C | S | V | D}")
                            }; 
                    }        
                },

                // Set Dependentes
                line => {c.Dependentes = uint.Parse(line);}
            };

            // Cada iteração escreve um campo do objeto cliente
            foreach (var (message, action) in messages.Zip(actions))
            {
                // Itera até o usuário informar um valor válido para o campo corrente
                do
                {
                    // Escreve qual campo está sendo solicitado, baseado na variável @messages
                    Console.WriteLine(message);

                    // Lê linha da entrada
                    line = Console.ReadLine();

                    try
                    {
                        // Invoca a ação associada ao campo corrente 
                        action(line);

                         /* Se o campo for válido, o programa sai do loop while
                          e vai para o próximo campo no foreach */
                        break;

                        /* Caso contrário, isto é, se alguma exceção for lançada,
                         * o programa continuará no loop while, até que um válido
                         * para o campo corrente seja informado
                         */
                    }
                    catch (Cliente.InvalidClientException e)
                    {
                        Console.WriteLine("Erro: {0}", e.Message);
                    }
                    catch (Exception e) when (e is OverflowException || e is FormatException)
                    {
                        Console.WriteLine("Erro: Valor informado não é sequencia de dígitos\n{0}", e.Message);
                    }
                    catch (ArgumentOutOfRangeException e) 
                    {
                        Console.WriteLine("Erro: Data Informada não é válida\n{0}", e.Message);
                    } 
                    catch (InvalidEstadoCivilException e)
                    {
                        Console.WriteLine("Erro: Estado Civil informado é inválido.\n{0}", e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Erro: Algo inesperado ocorreu.\n{0}", e.Message);
                    }
                } while (true);
            }

            Console.WriteLine(c);
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
