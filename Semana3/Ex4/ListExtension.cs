using System.Collections.Generic;


namespace Ex4
{
    internal static class ListExtension
    {
        public static void RemoveRepetidos<T>(this List<T> list)
        {
            HashSet<T> set = new HashSet<T>();

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
