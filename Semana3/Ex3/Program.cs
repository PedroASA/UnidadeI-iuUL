using System;

namespace Ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for(uint i=1; i<10000; i++)
            {
                if(i.IsArmstrong())
                    Console.WriteLine(i);
            }
        }
    }
}
