using System;
using System.Globalization;
using System.Linq;

namespace Ex1.Cliente
{
    public class ClienteBuilder
    {
        private Cliente cliente;
        private readonly InvalidClienteException[] erros = new InvalidClienteException[6];

        private readonly bool[] done = new bool[6];


        public string[] Erros
        {
            get
            {
                return erros.Select(x => x?.Message).ToArray();
            }
        }

        public string AllErros
        {
            get
            {
                return erros.Aggregate("", (acc, x) => acc + "\n" + x?.Message);
            }
        }

        public bool[] Done
        {
            get
            {
                return (bool[]) done.Clone();
            }
        }

        public ClienteBuilder()
        {
            cliente = new();
        }

        public Cliente TryBuild()
        {
            if (done.All(x=> x))
            {
                return cliente;
            }
            return null;
        }

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
        /*TODO*/
        // Chain of Responsabilty
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

        public string ToJson()
        {
            return cliente.ToJson();
        }
    }
}
