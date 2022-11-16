using System;

namespace Ex2
{
    internal class Program
    {
        // Evitar Warning do Compilador
        #pragma warning disable IDE0060
        internal static void Main(string[] args)
        {
            // Testa os métodos públicos implementados em Vertice.cs
            Vertice v1 = new (0.0, 0.0);
            Vertice v2 = new (-2.5, -2.5);
            Console.WriteLine("{0}\t{1}", v1, v2);
            Console.WriteLine(v1.Equals(v2));

            Console.WriteLine(v1.Distancia(v2));

            v2.Move(0.0,0.0);
            Console.WriteLine(v1);
            Console.WriteLine(v1.Equals(v2));
        }
    }
}
