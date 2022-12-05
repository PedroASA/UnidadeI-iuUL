using System.Collections.Generic;

namespace Ex1.Format
{
    public interface IFormat<I, O>
    {
        public string Encode(O obj);

        public I Decode(string json);

    }
}
