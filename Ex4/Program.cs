using System;

namespace Ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Collections.Generic.List<int> l1 = new(new int[]{ 1, 2,3, 4,5 ,6, 5, 3 ,2});

            System.Collections.Generic.List<string> l2 = new(new string[] { "a", "b", "b", "a", "b", "c" });

            System.Collections.Generic.List<Cliente> l3 = new(new Cliente[] 
            {
                new Cliente("Nome1", 1),
                new Cliente("Nome2", 2),
                new Cliente("Nome3", 3),
                new Cliente("Nome2", 5),
                new Cliente("Nome1", 1),
                new Cliente("Nome2", 2),

            });

            l1.RemoveRepetidos();
            l2.RemoveRepetidos();
            l3.RemoveRepetidos();

            l1.ForEach(Console.WriteLine);
            Console.WriteLine();
            l2.ForEach(Console.WriteLine);
            Console.WriteLine();
            l3.ForEach(Console.WriteLine);
        }

        private class Cliente
        {
            public string nome;
            public int cpf;

            public Cliente(string nome, int cpf)
            {
                this.nome = nome;
                this.cpf = cpf;
            }

            public override bool Equals(object obj)
            {
                return obj is Cliente c && c == this;
            }

            public static bool operator==(Cliente a, Cliente b)
            {
                return a.cpf == b.cpf;
            }

            public static bool operator !=(Cliente a, Cliente b)
            {
                return !(a == b);
            }

            public override int GetHashCode()
            {
                return cpf.GetHashCode();
            }

            public override string ToString()
            {
                return $"Nome: {nome}\tCpf: {cpf}";
            }
        }
    }
}
