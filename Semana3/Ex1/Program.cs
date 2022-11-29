using Ex1.Controller;
using Ex1.Format;
using Ex1.UI;

namespace Ex1
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            new NonInteractiveClienteController(new FileUI(args[0], args[1], new JsonFormat())).ReadAndWrite();

            new InteractiveClienteController(new ConsoleUI()).ReadAndWrite();
        }
    }
}