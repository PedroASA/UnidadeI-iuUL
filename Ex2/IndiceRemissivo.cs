using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ex2
{
    internal class IndiceRemissivo
    {
        // Mapeia palavras do texto e as linhas em que aparecem
        private readonly SortedDictionary<string, List<int>> wordsMap =new();

        // Conjunto de palavras a serem ignoradas
        private HashSet<string> ignoredWords = new();

        // Padrão de palavra a ser aceito
        private static readonly string pattern = "[A-Z]+([" + Regex.Escape(".,;<>:\\/|~^\'\"[]{}‘“!@#$%&*()_+=") + "][A-Z]+)*";

        private readonly Task waitRead;

        internal IndiceRemissivo(string pathTXT, string pathIgnore = null)
        {
            if (pathIgnore is not null) ReadIgnored(pathIgnore).Wait();
            this.waitRead = ReadText(pathTXT);
        }

        // Coleta as palavras do texto
        private static string[] GetWords(string text)
        {
            return Regex.Matches(text, pattern).Cast<Match>().Select(m => m.Value).ToArray();
        }

        // Lê arquivo de texto, converte todas as letras para maiúsculas e armazena em $wordsMap, se não for uma palavra a ser ignorada
        private async Task ReadText(string path)
        {
            try
            {
                var text = await File.ReadAllLinesAsync(path);
                var lines = text.Select((x, index) => (index, GetWords(x.ToUpper())));

                foreach ((var line, var words) in lines)
                {
                    foreach (var word in words)
                    {
                        if (!ignoredWords.Contains(word))
                            Add(word, line);
                    }
                }
            }
            catch(Exception)
            {
                throw new Exception($"Um erro ocorreu durante a leitura do arquivo \"{path}\"");
            }
}
        // Adiciona palavra ao $wordsMap
        private void Add(string word, int line)
        {
            if(wordsMap.ContainsKey(word))
            {
                wordsMap.TryGetValue(word, out List<int> set);

                set.Add(line);
            }
            else
                wordsMap.Add(word, new List<int>{line});
        }

        // Lê arquivo de palavras a serem ignoradas, converte todas as letras para maiúsculas e as armazena em $ignoredWords
        private async Task ReadIgnored(string path)
        {
            try
            {
                var text = await File.ReadAllTextAsync(path);
                var words = GetWords(text.ToUpper());
                ignoredWords = new HashSet<string>(words);

            }catch(Exception)
            {
                throw new Exception($"Um erro ocorreu durante a leitura do arquivo \"{path}\"");
            }
}
        // Aguarda o término da leitura dos arquivos e retorna o Output formatado
        public override string ToString()
        {
            waitRead?.Wait();
            return wordsMap.Aggregate("", 
                (acc, x) => acc + "\n" + 
                $"{x.Key} ({x.Value.Count}) {x.Value.Distinct().Aggregate("", (acc, e) => acc + " " + e)}");
        }
    }
}
