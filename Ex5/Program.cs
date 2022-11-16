using System;

namespace Ex5
{
    internal class Program
    {
#pragma warning disable IDE0060 // Remover o parâmetro não utilizado
        internal static void Main(string[] args)
#pragma warning restore IDE0060 // Remover o parâmetro não utilizado
        {
            // Testa funcionamento da classe Intervalo
            try
            {
                Intervalo i = new(new DateTime(2010, 1, 1, 8, 0, 15), new DateTime(2010, 1, 1, 8, 0, 10));
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            Intervalo _i = new(new DateTime(2010, 1, 1, 8, 0, 15), new DateTime(2010, 8, 18, 13, 30, 30));
            Intervalo _i2 = new(new DateTime(2010, 1, 1, 8, 0, 1), new DateTime(2010, 1, 1, 8, 0, 15));

            Console.WriteLine(_i.TemIntersecao(_i2));
            Console.WriteLine(_i.Equals(_i2));
            Console.WriteLine(_i2.Duracao);
        }
    }
}
