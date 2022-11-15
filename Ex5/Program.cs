using System;

namespace Ex5
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
