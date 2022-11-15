using System;
using Ex2;

namespace Ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Poligono p = new(new Vertice(1.0, 1.0), new Vertice(1.0, -1.0), new Vertice(-1.0, -1.0));


            Console.WriteLine("Número de Vértices: {0}", p.N);
            Console.WriteLine("Perímetro: {0}", p.GetPerimetro());

            p.AddVertice(new Vertice(-1.0, 1.0));

            Console.WriteLine("Número de Vértices: {0}", p.N);
            Console.WriteLine("Perímetro: {0}", p.GetPerimetro());

            try
            {
                p.RemoveVertice(new Vertice(-1.0, 1.0));
                p.RemoveVertice(new Vertice(1.0, 1.0));
            } 
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Poligono p2 = new(new Vertice(3.2, -1.5), new Vertice(8.0, 0.0));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
