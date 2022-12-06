using Ex1.UI;
using Ex1.Format;

/*
 * Classe abstrata que molda como um controlador deve agir
 */

namespace Ex1.Controller
{
    internal abstract class ClienteController
    {
        protected readonly IUserInterface userInterface;


        public ClienteController(IUserInterface userInterface)
        {
            this.userInterface = userInterface;
        }

        public abstract void ReadAndWrite();
    }
}
