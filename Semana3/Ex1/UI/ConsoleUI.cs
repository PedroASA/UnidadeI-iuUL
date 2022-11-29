using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
