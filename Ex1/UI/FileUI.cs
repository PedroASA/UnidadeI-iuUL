using Ex1.Format;
using System.Collections.Generic;
using System.IO;

/*
 * Implementa métodos Read e Write para interação com um ou dois arquivo
 */

namespace Ex1.UI
{
    internal class FileUI : IUserInterface
    {
        private readonly StreamReader sr;

        private readonly StreamWriter sw;

        private readonly string input;

        public FileUI(string inFile, string outFile)
        {
            sr = new StreamReader(inFile);
            sw = new StreamWriter(outFile);

            input = sr.ReadToEnd();

            sr.Close();
        }

        ~FileUI()
        {
            sw.Close();
        }

        public void WriteOut(object obj)
        {

            sw.Write(obj);
            sw.Flush();
        }

        public string Read()
        {
            return input;
        }

        public void WriteErr(object obj)
        {

            sw.Write(obj);
            sw.Flush();
        }
    }
}
