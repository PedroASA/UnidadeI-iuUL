using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ex1
{

    internal class Cliente
    {

        // Backing Fields
        private string _nome;
        private ulong _cpf;
        private DateTime _dataDeNascimento;
        private float _rendaMensal;
        private int _dependentes;

        internal string Nome
        {
            // Verifica que nome tem 5 ou mais caracteres (letras, números, char especiais, etc).
            set
            {
                if (value.Length >= 5)
                {
                    this._nome = value;
                }
                else
                {
                    throw new InvalidClientException("Nome", value, "Nome do Cilente deve ter ao menos 5 caracteres");
                }
            }
            private get => _nome;
        }
        internal ulong Cpf
        {
            // Verifica se cpf é válido. Caso não seja, é lançada uma exceção do tipo InvalidClientException
            set
            {
                this._cpf = TipoCpf.Verify(value.ToString());
            }
            private get => this._cpf;
        }

        internal DateTime DataDeNascimento
        {
            // Verifica que idade maior ou igual a dezoito
            // https://pt.stackoverflow.com/a/157496
            set
            {
                var today = DateTime.Now;
                var age = today.Year - value.Year;
                if (value > today.AddYears(-age)) age--;

                if (age >= 18)
                {
                    this._dataDeNascimento = value;
                }
                else
                {
                    throw new InvalidClientException("Data De Nascimento", value.ToString("d", DateTimeFormatInfo.InvariantInfo), "Idade do Cilente deve ser ao menos 18 anos.");
                }
            }
            private get => this._dataDeNascimento;
        }

        internal float RendaMensal
        {
            private get => this._rendaMensal;

            // Verifica que renda mensal é maior ou igual a zero
            // inútil - Já é verificado em TipoRendaMensal.Parse()
            set
            {
                if(value < 0 )
                    throw new InvalidClientException("Renda Mensal", value, "Renda Mensal deve ser um valor não negativo");
                this._rendaMensal = value;

            }

        }
        internal TipoEstadoCivil EstadoCivil { private get; set; }
        internal int Dependentes
        {
            private get => this._dependentes;

            // Verifica que dependentes é no máximo 10 e no mínimo 0
            set
            {
                if (value <= 10 && value >= 0)
                {
                    this._dependentes = value;
                }
                else
                {
                    throw new InvalidClientException("Dependentes", value, "Número de dependentes do Cilente deve ser no máximo 10 e ao menos zero.");
                }
            }
        }

        // Usado para imprimir informações do cliente
        public override string ToString()
        {
            string[] x = { "Nome do Cliente:", "CPF:", "Data de Nascimento:", "Renda Mensal:", "Estado Civil:", "Dependentes:" };
            object[] y = { Nome, Cpf.ToString(CultureInfo.InvariantCulture), DataDeNascimento.ToString("d", DateTimeFormatInfo.InvariantInfo), _rendaMensal.ToString("0.00"), EstadoCivil, Dependentes };

            return x
                .Zip(y, (first, second) => $"{first,-25}{second,15}\n")
                .Aggregate("\n\nUsuário\n", (acc, x) => acc + x);
        }

        /* 
         * Exceções da forma
         *  Erro => Campo: $campo   Valor: $valor   Mensagem: $mensagem
         */
        internal class InvalidClientException : Exception
        {
            public InvalidClientException(string fieldName, object val, string message)
                : base(MakeMessage(fieldName, val, message))
            { }

            internal static string MakeMessage(string fieldName, object val, string message)
            {
                return $"Erro => Campo: {fieldName, -20} Valor: {(val.ToString().Length == 0? "N/A": val), 5}\t\t Mensagem: {message, 53}";
            }
        }

        /*
         * Struct específico para validar se uma string pode ser rendaMensal
         */
        internal readonly struct TipoRendaMensal
        {

            // Padrões aceitos {0,00 | 0 | 0,0 | 000000}
            private static readonly Regex rx = new (@"^\s*\d+(,\d\d?)?\s*$", RegexOptions.Compiled);

            internal static float Parse(string s)
            {
                if (rx.IsMatch(s))
                    return float.Parse(s);
                else
                    throw new InvalidClientException("Renda Mensal", s, "Renda Mesnsal deve ser não negativo e possuir até duas casas decimais separadas por vírgula");
            }
        }

        /*
         * Struct específico para validar se uma string pode ser um cpf válido
         */
        private readonly struct TipoCpf
        {
            private static int[] Seq(int x) => Enumerable.Range(2, x).Reverse().ToArray();
            internal static ulong Verify(string s)
            {
                string message;
                if (s.Length == 11)
                {
                    if(s.Distinct().Count() != 1)
                    {
                        if (IsDv(s, 9) && IsDv(s, 10))
                        {
                            return ulong.Parse(s);
                        }
                        else
                        {
                            message = "Cpf do Cilente deve ter dígitos verficadores válidos";
                        }
                    } else
                    {
                        message = "Cpf do Cilente não pode ter todos os dígitos iguais";
                    }
                }
                else
                {
                    message = "Cpf do Cilente deve ter 11 dígitos";
                }
                throw new InvalidClientException("CPF", s, message);
            }

            // Verifica se o (penúltimo ou último - parâmetro $lst) dígito é válido
            private static bool IsDv(string s, int lst)
            {
                var lstDigit = int.Parse($"{s[lst]}");
                var mod =
                    s.Remove(lst).ToCharArray()
                    .Zip(Seq(lst), (x, y) => int.Parse($"{x}") * y)
                    .Aggregate(0, (acc, e) => acc + e)
                    % 11;
 
                return 
                    mod switch
                    {
                        0 | 1 => lstDigit == 0,
                        _ => lstDigit == 11 - mod,
                    };
            }
        }
    }
}