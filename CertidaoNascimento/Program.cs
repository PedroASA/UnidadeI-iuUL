using System;

namespace Ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pessoa p = new("Pedro");

            p.SetCertidao(new DateTime(2000, 1, 1));

            Console.WriteLine(p);

            Pessoa _p = new("Pessoa A");

            Console.WriteLine(_p);
        }
    }
}
