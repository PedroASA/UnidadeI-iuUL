using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex6
{
    internal abstract class Progressao
    {
        public int Primeiro { get; set; }

        public int Razao { get; set; }

        public abstract int ProximoValor { get; protected set; }

        public Progressao(int primeiro, int razao)
        {
            Primeiro = primeiro;
            Razao = razao;
            ProximoValor = primeiro;
        }

        public abstract int TermoAt(int posicao);

        public void Reinicializar()
        {
            ProximoValor = Primeiro;
        }
    }
}
