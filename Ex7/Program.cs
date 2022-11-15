using System;
using System.Linq;

namespace Ex7
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            Cliente c = new();
            string line;

            string[] messages = { 
                "Nome do Cliente:", 
                "CPF:", 
                "Data de Nascimento:", 
                "Renda Mensal:", 
                "Estado Civil:", 
                "Dependentes:" 
            };

            Action<string>[] actions =
            {
                // Set Nome
                line => {c.Nome = line.Trim();},

                // Set CPF
                line => { c.Cpf = ulong.Parse(line); },

                // Set Data de Nascimento
                line =>
                {
                    var data = line.Split('/').Select(Int32.Parse).Reverse();
                    c.DataDeNascimento = new DateTime(data.First(), data.ElementAt(1), data.Last());
                },

                // Set Renda Mensal
                line => 
                {
                    //if(line.Split(",").Count() > 0)
                    //{

                    //}
                    c.RendaMensal = float.Parse(line);
                },

                // Set Estado Civil
                line =>
                {
                    if(line.Length != 1)
                    {
                        throw new InvalidEstadoCivilException("Estado Civil deve conter apenas um caracter!");
                    } else
                    {
                        switch(Char.ToUpper(line[0]))
                        {
                            case 'C':
                                c.EstadoCivil = Cliente.TipoEstadoCivil.CASADO;
                                break;
                            case 'S':
                                c.EstadoCivil = Cliente.TipoEstadoCivil.SOLTEIRO;
                                break;
                            case 'V':
                                c.EstadoCivil = Cliente.TipoEstadoCivil.VIUVO;
                                break;
                            case 'D':
                                c.EstadoCivil = Cliente.TipoEstadoCivil.DIVORCIADO;
                                break;
                            default:
                                throw new InvalidEstadoCivilException("Entrada Inválida. Estado Civil deve ser {C | S | V | D}");
                        }
                    }
                },

                // Set Dependentes
                line => {c.Dependentes = uint.Parse(line);}
            };


            foreach (var (message, action) in messages.Zip(actions))
            {
                do
                {
                    Console.WriteLine(message);
                    line = Console.ReadLine();
                    try
                    {
                        action(line);
                        break;
                    }
                    catch (Cliente.InvalidClientException e)
                    {
                        Console.WriteLine("Erro: {0}", e.Message);
                    }
                    catch (Exception e) when (e is OverflowException || e is FormatException)
                    {
                        Console.WriteLine("Erro: Valor informado não é sequencia de dígitos\n{0}", e.Message);
                    }
                    catch (ArgumentOutOfRangeException e) 
                    {
                        Console.WriteLine("Erro: Data Informada não é válida\n{0}", e.Message);
                    } 
                    catch (InvalidEstadoCivilException e)
                    {
                        Console.WriteLine("Erro: Estado Civil informado é inválido.\n{0}", e.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Erro: Algo inesperado ocorreu.\n{0}", e.Message);
                    }
                    continue;
                } while (true);
            }

            Console.WriteLine(c);
        }

        private class InvalidEstadoCivilException : Exception
        {
            public InvalidEstadoCivilException(string message)
            : base(message)
            { }
        }
    }
}
