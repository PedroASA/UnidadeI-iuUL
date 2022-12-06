using Ex1.Format;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Ex1.ClienteNamespace
{
    public partial class Cliente
    {
        public string Nome { get; private set; }
        public ulong Cpf { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public float RendaMensal { get; private set; }
        public TipoEstadoCivil EstadoCivil { get; private set; }
        public int Dependentes { get; private set; }

        private Cliente() { }

        // Usado para imprimir informações do cliente
        public override string ToString()
        {
            string[] x = { "Nome do Cliente:", "CPF:", "Data de Nascimento:", "Renda Mensal:", "Estado Civil:", "Dependentes:" };
            object[] y = { Nome, Cpf.ToString(CultureInfo.InvariantCulture), DataDeNascimento.ToString("d", DateTimeFormatInfo.InvariantInfo), RendaMensal.ToString("0.00"), EstadoCivil, Dependentes };

            return x
                .Zip(y, (first, second) => $"{first,-25}{second,15}\n")
                .Aggregate("\n\nUsuário\n", (acc, x) => acc + x);
        }
    }
}