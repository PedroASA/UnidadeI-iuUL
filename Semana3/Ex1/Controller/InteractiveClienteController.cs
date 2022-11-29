using System.Linq;
using System.Threading.Tasks;
using Ex1.UI;
using TipoClienteBuilder = Ex1.Cliente.ClienteBuilder;

namespace Ex1.Controller
{
    internal class InteractiveClienteController : ClienteController
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

        public InteractiveClienteController(IUserInterface userInterface)
            : base(userInterface) { }

        public override void ReadAndWrite()
        {
            TipoClienteBuilder builder = new();

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

        private void ProcessField(TipoClienteBuilder cB, int index)
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
