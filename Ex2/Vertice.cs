using System;

namespace Ex2
{
    // A classe é publica pois será usada em outro namespace (Projeto 3)
#pragma warning disable CS0659 // O tipo substitui Object. Equals (objeto o), mas não substitui o Object.GetHashCode()
#pragma warning disable CS0661 // O tipo define os operadores == ou !=, mas não substitui o Object.GetHashCode()
    public class Vertice
#pragma warning restore CS0661 // O tipo define os operadores == ou !=, mas não substitui o Object.GetHashCode()
#pragma warning restore CS0659 // O tipo substitui Object. Equals (objeto o), mas não substitui o Object.GetHashCode()
    {
        // leitura pública e escrita privada
        public double X { get; private set; }
        public double Y { get; private set; }
        public Vertice(double x, double y)
        {
            (this.X, this.Y) = (x, y);
        }

        // Raiz Quadrada { (x1 - x2)^2 + (y1 - y2)^2 }
        public double Distancia(Vertice that)
            => Math.Sqrt(
                Math.Pow(this.X - that.X, 2)
                + Math.Pow(this.Y - that.Y, 2));


        public void Move(double x, double y)
        {
            (this.X, this.Y) = (x, y);
        }

        // Método para comparar dois Triângulos
        public override bool Equals(object obj)
            => obj is Vertice that && this == that;

        // Usado depois para imprimir os Vértices
        public override string ToString()
            => $"({X}, {Y})";

        // Usado depois no Projeto 3, no método Triangulo.Equals
        public static bool operator ==(Vertice v1, Vertice v2)
            => (v1.X == v2.X) && (v1.Y == v2.Y);

        // A linguagem obriga a implementação dos dois operadores
        public static bool operator !=(Vertice v1, Vertice v2)
            => !(v1 == v2);
    }
}