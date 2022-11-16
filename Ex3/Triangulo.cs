using System;
// usar classe Vertice do projeto anterior
using Ex2;

namespace Ex3
{
#pragma warning disable CS0659 // O tipo substitui Object. Equals (objeto o), mas não substitui o Object.GetHashCode()
    internal class Triangulo
#pragma warning restore CS0659 // O tipo substitui Object. Equals (objeto o), mas não substitui o Object.GetHashCode()
    {
        internal Vertice V1 { get; private set; }
        internal Vertice V2 { get; private set; }
        internal Vertice V3 { get; private set; }

        internal double Perimetro { get; private set; }

        internal enum TipoTriangulo
        {
            EQUILATERO, ISOSCELES, ESCALENO
        };
        internal TipoTriangulo Tipo { get; private set; }

        internal double Area { get; private set; }

        private readonly double lado1, lado2, lado3;



        // Construtor inicializa todos os campos do Objeto
        internal Triangulo(Vertice v1, Vertice v2, Vertice v3)
        {
            if (!IsTriangulo(v1, v2, v3))
            {
                throw new InvalidTrianguloException(String.Format("Erro: Os vértices {0}, {1}, {2} não formam um triangulo.", v1, v2, v3));
            }

            (this.V1, this.V2, this.V3) = (v1, v2, v3);

            (lado1, lado2, lado3) = (v1.Distancia(v2), v2.Distancia(v3), v3.Distancia(v1));

            Perimetro = lado1 + lado2 + lado3;

            Area = CalcArea();

            Tipo = CalcTipo();
        }

        /*
         * Método para verificar se dois triangulos são iguais.
         * Dois triângulos são iguais se seus vértice são iguais
         */
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            var that = (Triangulo)obj;
            return (this.V1, this.V2, this.V3) == (that.V1, that.V2, that.V3);
        }

        // Formula do Enunciado
        private double CalcArea()
        {
            var s = Perimetro / 2;

            return Math.Sqrt(s * (s - lado1) * (s - lado2) * (s - lado3));
        }

        /*
         * Verifica se área do triângulo é diferente de zero, ou seja, se o triangulo existe.
         * 
         *  Area = |(x2−x1)(y3−y1)−(y2−y1)(x3−x1)|
         *  https://math.stackexchange.com/a/937781
         */
        private static bool IsTriangulo(Vertice v1, Vertice v2, Vertice v3)
        {
            var (x1, x2, x3) = (v1.X, v2.X, v3.X);
            var (y1, y2, y3) = (v1.Y, v2.Y, v3.Y);

            double a = x1 * (y2 - y3)
                + x2 * (y3 - y1)
                + x3 * (y1 - y2);

            return a != 0;
        }

        private TipoTriangulo CalcTipo()
        {
            var (eq1, eq2) = (lado1 == lado2, lado2 == lado3);

            if (eq1 && eq2)
                return TipoTriangulo.EQUILATERO;
            else if (eq1 || eq2 || lado3 == lado1)
                return TipoTriangulo.ISOSCELES;
            else
                return TipoTriangulo.ESCALENO;
        }

        internal class InvalidTrianguloException : Exception
        { 
            internal InvalidTrianguloException(string message)
                : base(message)
            { }
        }
    }
}