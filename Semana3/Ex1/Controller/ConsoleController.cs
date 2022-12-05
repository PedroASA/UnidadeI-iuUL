using System.Linq;
using System.Threading.Tasks;
using Ex1.UI;
using Ex1.ClienteNamespace;
using System;

/*
 * Controlador que interage com os objetos ConsoleUI
 * Implementa a criação de um cliente a partir da interação com o console
 */

namespace Ex1.Controller
{
    internal class ConsoleController : ClienteController
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

        private static readonly Action<Cliente.ClienteBuilder, string>[] actions =
            {
                // Set Nome
                (cB, line) => {cB.SetNome(line);},

                // Set CPF
                (cB, line) => { cB.SetCpf(line); },

                // Set Data de Nascimento
                (cB, line) => { cB.SetDataDeNascimento(line); },

                // Set Renda Mensal
                (cB, line) => { cB.SetRendaMensal(line); },

                // Set Estado Civil
                (cB, line) => { cB.SetEstadoCivil(line); },

                // Set Dependentes
                (cB, line) => { cB.SetDependentes(line); }
        };

        public ConsoleController(ConsoleUI userInterface)
            : base(userInterface) { }

        public override void ReadAndWrite()
        {
            Cliente.ClienteBuilder builder = new();

            // Enquanto existir pelo menos um campo não válido
            do
            {
                // Ler entrada para todos campos não aceitos
                for (int i = 0; i < builder.Done.Length; i++)
                {
                    if (!builder.Done[i])
                        ProcessField(builder, i);
                }
                userInterface.WriteOut(builder.AllErros);
            } while (builder.Done.Any(x => !x));

            userInterface.WriteOut(builder.TryBuild());
        }

        private void ProcessField(Cliente.ClienteBuilder cB, int index)
        {
            // Escreve qual campo está sendo solicitado, baseado na variável @messages
            userInterface.WriteOut(messages[index]);

            // Lê linha da entrada
            var line = userInterface.Read();

            // Invoca a ação associada ao campo corrente 
            actions[index](cB, line);
        }
    }
}
