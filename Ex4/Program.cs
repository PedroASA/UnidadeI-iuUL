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
        }
    }
}
