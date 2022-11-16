using System;
using Ex2;
namespace Ex3
{
    internal class Program
    {
        // Evitar Warning do Compilador
        #pragma warning disable IDE0060
        internal static void Main(string[] args)
        {
            // Testa os métodos implementados pela classe Trinagulo.cs
            var t1 = new Triangulo(new Vertice(-0.5,0), new Vertice(0.0, 0.86602540378443864676372317075294), new Vertice(0.5,0.0));

            Console.WriteLine("Perímetro: {0}", t1.Perimetro);
            Console.WriteLine("Área: {0}", t1.Area);
            Console.WriteLine("Tipo: {0}", t1.Tipo);

            try
            {
                var t2 = new Triangulo(new Vertice(0, 0), new Vertice(1, 0), new Vertice(3, 0));
            }
            catch (Triangulo.InvalidTrianguloException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
