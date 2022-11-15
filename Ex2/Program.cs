using System;

namespace Ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vertice v1 = new Vertice(1.0, 1.0);
            Vertice v2 = new Vertice(1.0, 0.0);
            Console.WriteLine("{0}\t{1}", v1, v2);
            Console.WriteLine(v1.Equals(v2));

            Console.WriteLine(v1.Distancia(v2));

            v2.Move(1.0,1.0);
            Console.WriteLine(v1);
            Console.WriteLine(v1.Equals(v2));

        }
    }
}
