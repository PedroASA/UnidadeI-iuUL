using System;

namespace Ex1
{
    internal class Piramide
    {
        private int _n;
        internal Piramide(int n)
        {
            if (n < 1)
            {
                throw new NonPositiveIntegerException(String.Format("Valor de N deve ser maior que zero.\nErro:\n\t{0} < 1", n));
            }

            _n = n;
        }

        /* Para que a pirâmide fique alinhada, 
         * calcula-se, primeiro, quantos espaços devem 
         * ser adicionados antes de cada linha
         */
        public void Desenha()
        {
            /*
             * Número de espaços antes da primeira linha 
             * é igual ao 
             * Número de characteres até o meio da última (N-ésima) linha
             * */
            int num_space = NumOfCharsToN();

            // Cada linha da pirâmide
            for (int i = 1; i <= _n; ++i)
            {
                // Imprimir espaços antes da linha $i da pirâmide
                Console.Write("{0}", new string(' ', num_space));

                //Quantidade de caracteres a mais na próxima linha
                int num_chars = (int)Math.Floor(Math.Log10(i)) + 1;
                // Quantidade de espaço antes da próxima linha da pirâmide
                num_space = num_space - num_chars;

                // Imprimir de 1..$i, onde $i é a linha corrente da pirâmide
                for (int j = 1; j <= i; ++j)
                {
                    Console.Write(j);
                }
                // Imprimir de $i-1..1 , onde $i é a linha corrente da pirâmide
                for (int j = i - 1; j >= 1; --j)
                {
                    Console.Write(j);
                }
                Console.WriteLine("");
            }
        }
        /* Calcula o número de dígitos para escrever de 1..N
         * 
         *      k(n+1) - (10^k - 1)/9, onde k é número de chars em N,i.e, log10(N)
         *      
         *      https://math.stackexchange.com/a/8644
         */
        private int NumOfCharsToN()
        {
            // Número de Caracteres de _n
            int k = (int)Math.Floor(Math.Log10(_n)) + 1;
            return k * (_n + 1) - ((int)Math.Pow(10, k) - 1) / 9;
        }

        // Uma classe de Exception própria para evitar lançar Exceções genéricas
        [Serializable]
        internal class NonPositiveIntegerException : Exception
        {
            public NonPositiveIntegerException(string message)
                : base(message)
            { }
        }
    }
}
