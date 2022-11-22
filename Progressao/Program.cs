using System;

namespace Ex6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Progressao[] progressoes = { new ProgressaoAritmetica(3, 4), new ProgressaoGeometrica(3, 4) };

            foreach (var prog in progressoes)
            {
                for (int i = 0; i < 10; ++i)
                {
                    Console.Write($"{prog.ProximoValor} ");
                }
                Console.WriteLine();
            }

            foreach (var prog in progressoes)
            {
                prog.Reinicializar();
                for (int i = 0; i < 10; ++i)
                {
                    Console.Write($"{prog.ProximoValor} ");
                }
                Console.WriteLine();
            }

            Progressao[] progs2 = { new ProgressaoAritmetica(progressoes[0].TermoAt(10), 4), new ProgressaoGeometrica(progressoes[1].TermoAt(10), 4) };

            foreach (var prog in progs2)
            {
                for (int i = 0; i < 2; ++i)
                {
                    Console.Write($"{prog.ProximoValor} ");
                }
                Console.WriteLine();
            }
        }
    }
}
