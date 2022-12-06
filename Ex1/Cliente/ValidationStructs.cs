using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ex1.ClienteNamespace
{
    public partial class Cliente
    {
        /*
        * Struct específico para validar se uma string pode ser um cpf válido
        */
        private readonly struct TipoCpf
        {
            private static int[] Seq(int x) => Enumerable.Range(2, x).Reverse().ToArray();
            internal static (bool, string) ValidaCpf(string s)
            {
                if (ulong.TryParse(s, out ulong _) && s.Length == 11)
                {
                    if (s.Distinct().Count() != 1)
                    {
                        if (IsDv(s, 9) && IsDv(s, 10))
                        {
                            return (true, null);
                        }
                        else
                        {
                            return (false, "Cpf do Cilente deve ter dígitos verficadores válidos");
                        }
                    }
                    else
                    {
                        return (false, "Cpf do Cilente não pode ter todos os dígitos iguais");
                    }
                }
                return (false, "Cpf do Cilente deve ter 11 dígitos");
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
                        0 or 1 => lstDigit == 0,
                        _ => lstDigit == 11 - mod,
                    };
            }
        }

        /*
         * Struct específico para validar se uma string pode ser rendaMensal
         */
        private readonly struct TipoRendaMensal
        {

            // Padrões aceitos {0,00 | 0 | 0,0 | 000000}
            private static readonly Regex rx = new(@"^\s*\d+(,\d\d?)?\s*$", RegexOptions.Compiled);

            internal static (bool, string) ValidaRendaMensal(string s)
            {
                return (rx.IsMatch(s), "Renda Mensal deve se adequar ao padrão 0.00, sendo positivo");
            }
        }
    }
}