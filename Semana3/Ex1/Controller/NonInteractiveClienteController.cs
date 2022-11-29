using System;
using System.Collections.Generic;
using System.Linq;
using Ex1.UI;
using TipoClienteBuilder = Ex1.Cliente.ClienteBuilder;

namespace Ex1.Controller
{
    internal class NonInteractiveClienteController : ClienteController
    {

        public NonInteractiveClienteController(IUserInterface userInterface)
            : base(userInterface){}

        public override void ReadAndWrite()
        {
            List<TipoClienteBuilder> builders = new ();

            bool sig = false;

            while (true)
            {
                var builder = new TipoClienteBuilder();

                for (int i = 0; i < actions.Length; i++)
                {
                    var line = userInterface.Read();
                    if (line == "EOT")
                    {
                        sig = true;
                        break;
                    }
                    actions[i](builder, line);
                }
                if (sig) break;
                builders.Add(builder);
            }
            userInterface.WriteOut(builders.Where(x=> x.Done.Any(e => !e)).ToList());
        }
    }
}
