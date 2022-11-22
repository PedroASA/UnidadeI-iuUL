using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex5
{
    internal class Carro
    {
        private readonly string placa, modelo;

        private Motor _motor;
        internal Motor Motor
        {
            private get => _motor;
            set 
            {
                if (value is null)
                    throw new Exception("Motor não pode ser nulo");

                _motor = value;
                _motor.Carro = this;
            
            }
        }

        internal Carro(string placa, string modelo, Motor motor)
        {
            this.placa = placa;
            this.modelo = modelo;
            this.Motor = motor;
        }

        internal int VelocidadeMaxima()
        {
            return this.Motor.cilindrada switch
            {
                <= 1.0f => 140,
                <= 1.6f => 160,
                <= 2.0f => 180,
                      _ => 220
            };
        }
    }
}
