using System;

namespace Ex6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProgressaoAritmetica pa = new(3, 4);

            for (int i = 0; i < 10; ++i)
            {
                Console.Write($"{pa.ProximoValor} ");
            }

            Console.WriteLine();

            ProgressaoGeometrica pg = new(3, 4);

            for (int i = 0; i < 10; ++i)
            {
                Console.Write($"{pg.ProximoValor} ");
            }

            Console.WriteLine();

            pa.Reinicializar();

            for (int i = 0; i < 4; ++i)
            {
                Console.Write($"{pa.ProximoValor} ");
            }
            Console.WriteLine();

            pg.Reinicializar();

            for (int i = 0; i < 4; ++i)
            {
                Console.Write($"{pg.ProximoValor} ");
            }
        }
    }
}
