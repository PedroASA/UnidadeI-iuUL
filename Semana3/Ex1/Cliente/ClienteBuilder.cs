using System;
using System.Globalization;
using System.Linq;

namespace Ex1.ClienteNamespace
{
    public partial class Cliente
    {
        public class ClienteBuilder
        {
            // Cliente a ser criado
            private readonly Cliente cliente;

            // Possíveis erros ocorridos
            private readonly InvalidClienteException[] erros = new InvalidClienteException[6];

            // Marca os campos já preenchidos
            private readonly bool[] done = new bool[6];

            // Retorna uma cópia dos erros ocorridos
            public InvalidClienteException[] Erros
            {
                get
                {
                    return (InvalidClienteException[]) erros.Clone();
                }
            }

            // Erros em forma de String
            public string AllErros
            {
                get
                {
                    return erros.Aggregate("", (acc, x) => acc + "\n" + x?.Message);
                }
            }

            // Retorna uma cópia do vetor que indica quais campos foram terminados
            public bool[] Done
            {
                get
                {
                    return (bool[])done.Clone();
                }
            }

            public ClienteBuilder()
            {
                cliente = new();
            }

            // Constroi um Cliente se todos os campos tiverem sido prenchidos com valores válidos
            public Cliente TryBuild()
            {
                if (done.All(x => x))
                {
                    return cliente;
                }
                return null;
            }

            // Valida e preenche Nome do Cliente
            public ClienteBuilder SetNome(string value)
            {
                if (value.Length >= 5)
                {
                    cliente.Nome = value;
                    done[0] = true;
                }
                else
                {
                    erros[0] = new InvalidClienteException("Nome", value, "Nome do Cilente deve ter ao menos 5 caracteres");
                }

                return this;
            }

            // Valida e preenche CPF do Cliente
            public ClienteBuilder SetCpf(string value)
            {
                var (valido, errorMessage) = TipoCpf.ValidaCpf(value);
                if (valido)
                {
                    cliente.Cpf = ulong.Parse(value);
                    done[1] = true;
                }
                else
                {
                    erros[1] = new InvalidClienteException("Cpf", value, errorMessage);
                }

                return this;
            }

            // Valida e preenche Data de nascimento do Cliente
            public ClienteBuilder SetDataDeNascimento(string value)
            {
                // Verifica que idade maior ou igual a dezoito
                // https://pt.stackoverflow.com/a/157496
                try
                {
                    var date = DateTime.ParseExact(value, "d", new CultureInfo("pt-BR"));
                    var today = DateTime.Today;
                    var age = today.Year - date.Year;
                    if (date > today.AddYears(-age)) age--;

                    if (age < 18)
                        throw new Exception();

                    cliente.DataDeNascimento = date;
                    done[2] = true;

                }
                catch (FormatException)
                {
                    erros[2] = new InvalidClienteException("Data de Nascimento", value, "Formato de data inválido");
                }
                catch (Exception)
                {
                    erros[2] = new InvalidClienteException("Data de Nascimento", value, "Idade do cliente deve ser maior ou igual a 18");
                }

                return this;
            }

            // Valida e preenche Renda Mensal do Cliente
            public ClienteBuilder SetRendaMensal(string value)
            {
                var (valido, errorMessage) = TipoRendaMensal.ValidaRendaMensal(value);
                if (valido)
                {
                    cliente.RendaMensal = float.Parse(value);
                    done[3] = true;
                }
                else
                {
                    erros[3] = new InvalidClienteException("Renda Mensal", value, errorMessage);
                }

                return this;
            }

            // Valida e preenche Estado Civil do Cliente
            public ClienteBuilder SetEstadoCivil(string value)
            {
                try
                {
                    cliente.EstadoCivil = Enum.Parse<TipoEstadoCivil>(value.Trim(), true);
                    done[4] = true;
                }
                catch (Exception)
                {
                    erros[4] = new InvalidClienteException("Estado Civil", value, "Estado Civil deve ser {C|V|D|S}");
                }
                return this;
            }

            // Valida e preenche Dependentes do Cliente
            public ClienteBuilder SetDependentes(string value)
            {
                // Verifica que dependentes é no máximo 10 e no mínimo 0
                try
                {
                    var tmp = int.Parse(value);
                    if (tmp > 10 || tmp < 0)
                        throw new Exception();

                    cliente.Dependentes = tmp;
                    done[5] = true;

                }
                catch (Exception e) when (e is FormatException || e is OverflowException)
                {
                    erros[5] = new InvalidClienteException("Dependentes", value, "Dependentes deve ser um número inteiro");
                }
                catch (Exception)
                {
                    erros[5] = new InvalidClienteException("Dependentes", value, "Dependentes deve ser no máximo 10 e no mínimo 0");
                }

                return this;
            }

            public override string ToString()
            {
                return cliente.ToString();
            }
        }
    }
}