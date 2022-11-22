using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Ex7
{
    internal class Propriedades
    {
        private readonly ConcurrentDictionary<string, string> propriedades = new();

        internal Propriedades() { }

        internal Propriedades(string path)
        {
            ReadFile(path).Wait();
        }

        private async Task ReadFile(string path)
        {
            // Ler todas as linhas async
            var lines = await File.ReadAllLinesAsync(path);

            // Processar linhas em paralelo
            lines.AsParallel().ForAll(
                line =>
                {
                    // Ignorar comentários no arquivo properties
                    if (line.Length != 0 && line[0] == '#')
                        return;

                    var tmp = line.Split('=');
                    if (tmp.Length == 2)
                    {
                        AddKey(tmp[0], tmp[1]);
                    }
                });
        }

        internal bool TryGetValue(string key, out string _val)
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
            if (Contains(key))
            {
                throw new Exception("Chave já existe");
            }
            propriedades.TryAdd(key, value);
        }

        internal async Task WriteToFile(string path)
        {
            var lines =
                propriedades
                .Keys
                .AsParallel()
                .Zip(propriedades.Values.AsParallel(), (k, v) => k + "=" + v);

            // Escrever todas as linhas async
            await File.WriteAllLinesAsync(path, lines);
        }
    }
}
