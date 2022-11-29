using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    internal static class NumerosArmstrong
    {
        public static bool IsArmstrong(this uint valor)
        {
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
