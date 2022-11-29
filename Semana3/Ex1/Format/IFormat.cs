using System.Collections.Generic;

namespace Ex1.Format
{
    public interface IFormat
    {
        public string Encode(object obj);

        public Queue<string> Decode(string json);
    }
}
