using System;
using Ex5;

namespace Ex6
{
    internal class Program
    {
#pragma warning disable IDE0060 // Remover o parâmetro não utilizado
        internal static void Main(string[] args)
#pragma warning restore IDE0060 // Remover o parâmetro não utilizado
        {
            ListaIntervalo li = new ();

            bool tmp;

            tmp = li.Add(new Intervalo(
                new DateTime(2010, 1, 1, 8, 0, 15), 
                new DateTime(2010, 1, 1, 8, 0, 19)));

            Console.WriteLine(tmp);

            // Tem Interseção com o intervalo acima
            tmp = li.Add(new Intervalo(
                new DateTime(2010, 1, 1, 8, 0, 15),
                new DateTime(2010, 1, 1, 8, 0, 18)));

            Console.WriteLine(tmp);

            tmp = li.Add(new Intervalo(
                new DateTime(2010, 1, 1, 8, 0, 30),
                new DateTime(2010, 1, 1, 8, 0, 58)));

            Console.WriteLine(tmp);

            tmp = li.Add(new Intervalo(
                new DateTime(2005, 1, 1, 8, 0, 30),
                new DateTime(2005, 1, 1, 8, 0, 58)));

            Console.WriteLine(tmp);

            tmp = li.Add(new Intervalo(
                new DateTime(2007, 1, 1, 8, 0, 30),
                new DateTime(2007, 1, 1, 8, 0, 58)));

            Console.WriteLine(tmp);

            tmp = li.Add(new Intervalo(
                new DateTime(2000, 1, 1, 8, 0, 30),
                new DateTime(2000, 1, 1, 8, 0, 58)));

            Console.WriteLine(tmp);

            li.Imprime();

        }
    }
}
