using System;

namespace Ex2
{
    public class Vertice
    {
        // leitura pública e escrita privada
        public double y { get; private set; }
        public double x { get; private set; }
        public Vertice(double x, double y)
        {
            (this.x, this.y) = (x, y);
        }

        public double Distancia(Vertice that)
            => Math.Sqrt(
                Math.Pow(this.x - that.x, 2)
                + Math.Pow(this.y - that.y, 2));


        public void Move(double x, double y)
        {
            (this.x, this.y) = (x, y);
        }

        public override bool Equals(object obj)
            => obj is Vertice && this == (Vertice)obj;

        public override string ToString()
            => $"({x}, {y})";

        public static bool operator ==(Vertice v1, Vertice v2)
            => (v1.x == v2.x) && (v1.y == v2.y);

        public static bool operator !=(Vertice v1, Vertice v2)
            => !(v1 == v2);
    }
}