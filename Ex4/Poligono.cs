using System;
using System.Collections.Generic;
using System.Linq;
using Ex2;

namespace Ex4
{
    internal class Poligono
    {
        private readonly List<Vertice> vertices;

        internal int N
        {
            get => vertices.Count;
            private set {}
        }
        internal Poligono(params Vertice[] vertices)
        {
            if(vertices.Length < 3)
            {
                throw new Exception(String.Format("Exception: Polígono deve ter ao menos 3 vértices. Apenas {0} foram vértices informados", vertices.Length));
            }

            this.vertices = vertices.ToList();
        }

        internal bool AddVertice(Vertice v)
        {
            if(!vertices.Contains(v))
            {
                vertices.Add(v);
                return true;
            }
            return false;
        }

        internal bool RemoveVertice(Vertice v)
        {
            if (vertices.Contains(v))
            {
                if (vertices.Count == 3) {
                    throw new Exception(String.Format("Exception: Polígono deve ter ao menos 3 vértices."));
                }
                vertices.Remove(v);
                return true;
            }
            return false;
        }
        /* Soma todos os lados do polígono
         * 
         * O polígono é formado de acordo com a ordem dada dos vértices
         * i.e, o primeiro vértice se conecta ao segundo que se conecta ao terceiro
         * e assim por diante
         */
        internal double GetPerimetro()
        {
            double sum = 0;
            for (int i = 0; i < N -1; ++i)
                sum += vertices[i].Distancia(vertices[i+1]);
            return sum + vertices[N-1].Distancia(vertices[0]);
        }
    }
}
