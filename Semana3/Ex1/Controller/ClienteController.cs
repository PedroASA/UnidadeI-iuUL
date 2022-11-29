using Ex1.UI;
using System;
using TipoClienteBuilder = Ex1.Cliente.ClienteBuilder;

namespace Ex1.Controller
{
    internal abstract class ClienteController
    {
        protected static readonly Action<TipoClienteBuilder, string>[] actions =
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

        protected readonly IUserInterface userInterface;

        public ClienteController(IUserInterface userInterface)
        {
            this.userInterface = userInterface;
        }

        public abstract void ReadAndWrite();
    }
}
