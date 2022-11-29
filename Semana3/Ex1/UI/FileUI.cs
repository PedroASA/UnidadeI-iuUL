using Ex1.Format;
using System.Collections.Generic;
using System.IO;

namespace Ex1.UI
{
    internal class FileUI : IUserInterface
    {
        private readonly StreamReader sr;

        private readonly StreamWriter sw;

        private readonly Queue<string> seq;

        private readonly IFormat format;

        public FileUI(string inFile, string outFile, IFormat format)
        {
            sr = new StreamReader(inFile);
            sw = new StreamWriter(outFile);

            this.format = format;

            string json = sr.ReadToEnd();
            sr.Close();
            seq = format.Decode(json);
        }

        ~FileUI()
        {
            sw.Close();
        }

        public void WriteOut(object obj)
        {

            sw.Write(format.Encode(obj));
            sw.Flush();
        }

        public string Read()
        {
            if ((seq.TryDequeue(out string tmp)))
                return tmp;
            return "EOT";
        }

        public void WriteErr(object obj)
        {

            sw.Write(format.Encode(obj));
            sw.Flush();
        }
    }
}
