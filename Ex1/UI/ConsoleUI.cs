using System;


/*
 * Implementa métodos Read e Write para interação com o Console
 */

namespace Ex1.UI
{
    internal class ConsoleUI : IUserInterface
    {
        public void WriteOut(object obj)
        {
            Console.WriteLine(obj);
        }

        public string Read()
        {
            return Console.ReadLine();
        }

        public void WriteErr(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
