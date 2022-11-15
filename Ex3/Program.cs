using System;
using Ex2;
namespace Ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t1 = new Triangulo(new Vertice(-0.5,0), new Vertice(0.0, 0.86602540378443864676372317075294), new Vertice(0.5,0.0));

            try
            {
                var t2 = new Triangulo(new Vertice(0, 0), new Vertice(1, 0), new Vertice(3, 0));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Perímetro: {0}", t1.perimetro);
            Console.WriteLine("Área: {0}", t1.area);
            Console.WriteLine("Tipo: {0}", t1.tipo);
        }
    }
}
