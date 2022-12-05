using System;
using Ex1.Format;

namespace Ex1.UI
{
    internal interface IUserInterface
    {
        public void WriteOut(object obj);
        public string Read();
        public void WriteErr(object obj);
    }
}
