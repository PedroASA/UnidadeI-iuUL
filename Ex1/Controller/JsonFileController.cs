using Ex1.ClienteNamespace;
using Ex1.Format;
using Ex1.UI;
using System.Collections.Generic;
using System.Linq;

/*
 * Controlador que interage com os objetos FileUI e JsonFormat
 * Implementa a criação de vários cliente a partir da leitura de um arquivo json
 */

namespace Ex1.Controller
{
    internal class JsonFileController: ClienteController
    {

        private readonly JsonFormat format;

        internal JsonFileController(FileUI userInterface, JsonFormat format) : base(userInterface) 
        {
            this.format = format; 
        }

        public override void ReadAndWrite()
        {
            var clientes = format.Decode(userInterface.Read());

            List<(Input, Cliente.ClienteBuilder)> badInputs = new();


            while (clientes.Count > 0)
            {
                var tmpCliente = clientes.Dequeue();
                var cliente = 
                    new Cliente.ClienteBuilder()
                .SetNome(tmpCliente.Nome)
                .SetCpf(tmpCliente.Cpf)
                .SetDataDeNascimento(tmpCliente.DataDeNascimento)
                .SetRendaMensal(tmpCliente.RendaMensal)
                .SetEstadoCivil(tmpCliente.EstadoCivil)
                .SetDependentes(tmpCliente.Dependentes);

                if(cliente.Done.Any(e => !e))
                {
                    badInputs.Add((tmpCliente, cliente));
                }
            }
            Write(badInputs);
        }

        private void Write(List<(Input, Cliente.ClienteBuilder)> data)
        {
            userInterface.WriteOut(format.Encode(data));
        }
    }
}
