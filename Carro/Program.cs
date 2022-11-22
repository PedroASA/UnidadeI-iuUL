using System;

namespace Ex5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Motor m = new(2.0f);
            Carro c = new("placa01", "modelo01", m);

            try
            {
                c.Motor = null;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Carro c2 = new("placa02", "modelo02", m);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(c.VelocidadeMaxima());
        }
    }
}
