using Ex1.Controller;
using Ex1.Format;
using Ex1.UI;
using Ex1.ClienteNamespace;

namespace Ex1
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            new JsonFileController(new FileUI(args[0], args[1]), new JsonFormat()).ReadAndWrite();

            // É possível também fazer como no exercício 2 (Criar um cliente por meio do Console:
            //new ConsoleController(new ConsoleUI()).ReadAndWrite();
        }
    }
}