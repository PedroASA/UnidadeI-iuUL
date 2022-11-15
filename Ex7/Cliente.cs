using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ex7
{

    internal class Cliente
    {
        private string _nome;
        private ulong _cpf;
        private DateTime _dataDeNascimento;
        private uint _dependentes;
        internal string Nome
        {
            set
            {
                if (value.Length >= 5)
                {
                    this._nome = value;
                }
                else
                {
                    throw new InvalidClientException(String.Format("Nome do Cilente deve ter ao menos 5 letras. {0} foram informadas", value.Length));
                }
            }
            private get => _nome;
        }
        internal ulong Cpf
        {
            set
            {
                int tmp = value.ToString().Length;
                if (tmp == 11)
                {
                    this._cpf = value;
                }
                else
                {
                    throw new InvalidClientException(String.Format("Cpf do Cilente deve ter 11 dígitos. {0} dígitos informados", tmp));
                }
            }
            private get => this._cpf;
        }

        internal DateTime DataDeNascimento
        {
            set
            {
                double age = (DateTime.Now - value).TotalDays / 365.2425;
                if (age >= 18)
                {
                    this._dataDeNascimento = value;
                }
                else
                {
                    throw new InvalidClientException(String.Format("Idade do Cilente deve ser ao menos 18 anos. Idade dada: {0}", age));
                }
            }
            private get => this._dataDeNascimento;
        }
        internal float RendaMensal { private get; set; }
        internal TipoEstadoCivil EstadoCivil { private get; set; }
        internal uint Dependentes
        {
            private get => this._dependentes;
            set
            {
                if (value <= 10)
                {
                    this._dependentes = value;
                }
                else
                {
                    throw new InvalidClientException(String.Format("Número de dependentes do Cilente deve ser no máximo 10. Número informado: {0}", value));
                }
            }
        }

        internal enum TipoEstadoCivil
        {
            CASADO,
            SOLTEIRO,
            VIUVO,
            DIVORCIADO
        }

        public override string ToString()
        {
            string[] x = {"Nome do Cliente:", "CPF:", "Data de Nascimento:", "Renda Mensal:", "Estado Civil:", "Dependentes:"};
            object[] y = {Nome, Cpf, DataDeNascimento.ToString("d", DateTimeFormatInfo.InvariantInfo), RendaMensal.ToString("0.00"), EstadoCivil, Dependentes};

            return x
                .Zip(y, (first, second) => $"{first, -10}{second, 20}\n")
                .Aggregate("\nUsuário\n", (acc, x) => acc + x);
        }

        internal class InvalidClientException : Exception
        {
            public InvalidClientException(string message)
            : base(message)
            { }
        }
    }
}
