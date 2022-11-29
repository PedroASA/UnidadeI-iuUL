using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Security;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Ex1.Cliente
{
    public class Cliente
    {
        public string Nome { get; set; }
        public ulong Cpf { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public float RendaMensal { get; set; }
        public TipoEstadoCivil EstadoCivil { get; set; }
        public int Dependentes { get; set; }

        internal Cliente() { }

        // Usado para imprimir informações do cliente
        public override string ToString()
        {
            string[] x = { "Nome do Cliente:", "CPF:", "Data de Nascimento:", "Renda Mensal:", "Estado Civil:", "Dependentes:" };
            object[] y = { Nome, Cpf.ToString(CultureInfo.InvariantCulture), DataDeNascimento.ToString("d", DateTimeFormatInfo.InvariantInfo), RendaMensal.ToString("0.00"), EstadoCivil, Dependentes };

            return x
                .Zip(y, (first, second) => $"{first,-25}{second,15}\n")
                .Aggregate("\n\nUsuário\n", (acc, x) => acc + x);
        }

        public string ToJson()
        {
            
            var options = new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) };
            return JsonSerializer.Serialize<Cliente>(this, options);
        }
    }
}