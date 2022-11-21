using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex6
{
    internal class ProgressaoGeometrica : Progressao
    {
        public ProgressaoGeometrica(int primeiro, int razao) 
            : base(primeiro, razao) { }

        private int _proximoValor;

        public override int ProximoValor
        {
            get
            {
                var tmp = _proximoValor;
                _proximoValor = tmp * Razao;
                return tmp;
            }
            protected set 
            {
                _proximoValor = value;
            }
        }

        // a0 * (1-q^n)/(1-q)
        public override int TermoAt(int posicao)
        {
            return Primeiro 
                * (1 - (int)Math.Pow(Razao, posicao)) 
                / (1 - Razao);
        }
    }
}
