using System;

namespace Ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IndiceRemissivo i = new(args[0], args[1]);

            Console.WriteLine(i.ToString());
        }
    }
}
