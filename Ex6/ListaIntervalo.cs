using System;
using System.Collections.Generic;
using Ex5;

namespace Ex6
{
    internal class ListaIntervalo
    {
        private readonly List<Intervalo> intervalos;
        internal ListaIntervalo() 
        { 
            intervalos = new List<Intervalo>();
        }

        internal bool Add(Intervalo i)
        {
            // Verifica interseções
            foreach (var e in intervalos)
            {
                if (e.TemIntersecao(i))
                {
                    return false;
                }
            }
            // Encontra posição na lista ordenada
            var index = find(i);

            intervalos.Insert(index, i);
            return true;
        }

        internal void Imprime()
            => intervalos.ForEach(Console.WriteLine);
        
        /*
         * A busca é feita de forma sequencial, pois já se
         * consome O(N) para verificar que não há interseções com 
         * os elementos da lista. Assim, não é necessário fazer uma busca em O(lg(N)),
         * visto que O(lg(N)) + O(N) = O(N) + O(N) = O(N).
         */
        private int find(Intervalo i)
        {
            var tmp = i.inicial;
            int index = -1;
            for (int j = 0; j < intervalos.Count; j++)
            {
                // Ordenada por inicial
                if (intervalos[j].inicial > tmp)
                {
                    index = j;
                    break;
                }
            }
            if (index == -1)
            {
                index = intervalos.Count;
            }
            return index;
        }
   
    }
}
