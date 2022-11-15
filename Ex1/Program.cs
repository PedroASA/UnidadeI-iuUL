using System;

namespace Ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int intTemp = Convert.ToInt32(args[0]);
            Piramide p = new Piramide(intTemp);
            p.Desenha();
        }
    }
}
