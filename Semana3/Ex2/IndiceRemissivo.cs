using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ex2
{
    internal class IndiceRemissivo
    {

        private SortedDictionary<string, SortedSet<int>> wordsMap =new();

        private HashSet<string> ignoredWords =new();

        private static readonly string pattern = "[A-Z]+([" + Regex.Escape(".,;<>:\\/|~^\'\"[]{}‘“!@#$%&*()_+=") + "][A-Z]+)*";

        internal IndiceRemissivo(string pathTXT, string pathIgnore ="")
        {
            if(pathIgnore !="") readIgnored(pathIgnore);
            readText(pathTXT);
        }

        private string[] GetWords(string text)
        {
            return Regex.Matches(text, pattern).Cast<Match>().Select(m => m.Value).ToArray();
        }

        private void readText(string path)
        {
            //try
            //{
                var lines = File.ReadLines(path).Select((x, index) => (index, GetWords(x.ToUpper())));

                foreach ((var line, var words) in lines)
                {
                    foreach (var word in words)
                    {
                        if(!ignoredWords.Contains(word))
                            Add(word, line);
                    }
                }
            //}catch(Exception)
            //{
            //    throw new Exception("Um erro ocorreu durante a leitura do arquivo");
            //}
        }

        private void Add(string word, int line)
        {
            if(wordsMap.ContainsKey(word))
            {
                wordsMap.TryGetValue(word, out SortedSet<int> set);

                set.Add(line);
            }
            else
                wordsMap.Add(word, new SortedSet<int>{line});
        }

        private void readIgnored(string path)
        {
            try
            {
                var words = GetWords(File.ReadAllText(path).ToUpper());
                ignoredWords = new HashSet<string>(words);

            }catch(Exception)
            {
                throw new Exception("Um erro ocorreu durante a leitura do arquivo");
            }
}

        public override string ToString()
        {
            return wordsMap.Aggregate("", 
                (acc, x) => acc + "\n" + 
                $"{x.Key} ({x.Value.Count}) {x.Value.Aggregate("", (acc, e) => acc + " " + e)}");
        }
    }
}
