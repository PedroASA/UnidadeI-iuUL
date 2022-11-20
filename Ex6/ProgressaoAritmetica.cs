﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex6
{
    internal class ProgressaoAritmetica : Progressao
    {
        public ProgressaoAritmetica(int primeiro, int razao) 
            :base(primeiro, razao) 
        {
            ProximoValor = primeiro;
        }

        private int _proximoValor;

        public override int ProximoValor {
            get
            {
                var tmp = _proximoValor;
                _proximoValor = tmp + Razao;
                return tmp;
            }
            protected set
            {
                _proximoValor = value;
            }
        }

        public override int TermoAt(int posicao)
        {
            return  Primeiro + (posicao - 1) * Razao;
        }


    }
}
