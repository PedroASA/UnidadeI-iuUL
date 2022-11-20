using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex5
{
    internal class Motor
    {
        private static readonly Dictionary<Motor, Carro> motorToCarro = new();

        internal readonly float cilindrada;

        internal Carro Carro
        {
            get
            {
                if(motorToCarro.TryGetValue(this, out Carro _c))
                {
                    return _c;
                }
                return null;
            }
            set {
                if (motorToCarro.TryGetValue(this, out Carro _c))
                    throw new Exception("Motor não pode ser alocado a dois carros diferentes");
                motorToCarro[this] = value;
            }
        }

        internal Motor(float cilindrada)
        {
            this.cilindrada = cilindrada;
        }


    }
}
