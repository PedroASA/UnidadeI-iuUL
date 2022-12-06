using System.Collections.Generic;


namespace Ex4
{
    internal static class ListExtension
    {
        // Método de Extensão da Classe List<T>
        public static void RemoveRepetidos<T>(this List<T> list)
        {
            // Elementos percorridos
            HashSet<T> set = new ();

            // Percorre a lista de trás para frente para já remover elemento repetido ao passar
            for (int i = list.Count-1; i >= 0; --i)
            {
                if (set.Contains(list[i]))
                    list.RemoveAt(i);
                else
                    set.Add(list[i]);
            }
        }
    }
}
