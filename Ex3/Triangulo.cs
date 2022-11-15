using System;
using Ex2;

public class Triangulo
{
	public Vertice v1{ get; private set; }
    public Vertice v2 { get; private set; }
    public Vertice v3 { get; private set; }

    public double perimetro { get; private set; }

    public enum Tipo {
        EQUILATERO, ISOSCELES, ESCALENO
    };
    public Tipo tipo { get; private set; }

    public double area { get; private set; }

    private double lado1, lado2, lado3;
    public Triangulo(Vertice v1, Vertice v2, Vertice v3)
	{
        if(!IsTriangulo(v1, v2, v3))
        {
            throw new InvalidTrianguloException(String.Format("Exception: Os vértices {0}, {1}, {2} não formam um triangulo.", v1, v2, v3));
        }

        (this.v1, this.v2, this.v3) = (v1, v2, v3);

        (lado1, lado2, lado3) = (v1.Distancia(v2), v2.Distancia(v3), v3.Distancia(v1));

        perimetro = lado1 + lado2 + lado3;

        area = CalcArea();

        tipo = CalcTipo();

	}

    public override bool Equals(object obj)
    {
        if (obj.GetType() != this.GetType()) return false;

        var that = (Triangulo)obj;
        return (this.v1, this.v2, this.v3) == (that.v1, that.v2, that.v3);
    }
    
    private double CalcArea()
    {
        var s = perimetro / 2;

        return Math.Sqrt(s * (s - lado1) * (s - lado2) * (s - lado3));
    }

    // Checa se área do triângulo é diferente de zero, ou seja, se o triangulo existe.
    private static bool IsTriangulo(Vertice v1, Vertice v2, Vertice v3)
    {
        var (x1, x2, x3) = (v1.x, v2.x, v3.x);
        var (y1, y2, y3) = (v1.y, v2.y, v3.y);

        double a = x1 * (y2 - y3)
            + x2 * (y3 - y1)
            + x3 * (y1 - y2);

        return a != 0;
    }

    private Tipo CalcTipo()
    {
        var (eq1, eq2) = (lado1 == lado2, lado2 == lado3);

        if (eq1 && eq2)
            return Tipo.EQUILATERO;
        else if (eq1 || eq2 || lado3 == lado1)
            return Tipo.ISOSCELES;
        else
            return Tipo.ESCALENO;
    }

    private class InvalidTrianguloException : Exception
    {

        public InvalidTrianguloException(string message)
            : base(message)
        { }
    }
}
