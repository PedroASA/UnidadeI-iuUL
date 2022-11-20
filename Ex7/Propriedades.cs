using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Ex7
{
    internal class Propriedades
    {
        private readonly Dictionary<string, string> propriedades = new();

        internal Propriedades() { }

        internal Propriedades(string path)
        {
            ReadFile(path);
        }

        private void ReadFile(string path)
        {
            Parallel.ForEach(System.IO.File.ReadLines(path),
                line =>
                {
                    var tmp = line.Split('=');
                    if (tmp.Length == 2)
                    {
                        AddKey(tmp[0], tmp[1]);
                    }
                }); 
        }

        internal bool GetValue(string key, out string _val)
        {
            return propriedades.TryGetValue(key, out _val);
        }

        internal void UpdateValue(string key, string val)
        {
            if(propriedades.ContainsKey(key))
                propriedades[key] = val;
            else
                throw new Exception("Chave não existe");
        }

        internal bool Contains(string key)
        {
            return propriedades.ContainsKey(key);
        }

        internal void AddKey(string key, string value)
        {
            if(Contains(key))
            {
                throw new Exception("Chave já existe");
            }
            propriedades.Add(key, value);
        }

        internal async Task WriteToFile(string path)
        {
            var lines =
                propriedades
                .Keys
                .Zip(propriedades.Values, (k, v) => k + "=" + v);

            await File.WriteAllLinesAsync(path, lines);
        }
    }
}
