using System;

namespace Ex3
{
    internal static class NumerosArmstrong
    {
        // Método de Extensão da Classe Uint
        public static bool IsArmstrong(this uint valor)
        {
            // Número de dígitos do número $valor
            int x = (int)Math.Log10((double)valor) + 1;

            uint temp, num = valor, sum=0, r;
            for (temp = num; num != 0; num = num / 10)
            {
                r = num % 10;
                sum = sum + (uint)Math.Pow(r,x);
            }
            return sum == temp;
        }
    }
}
