using System;

namespace Ex5
{
    public class Intervalo
    {
        public readonly DateTime inicial, final;

        public readonly TimeSpan Duracao;

    public Intervalo(DateTime inicial, DateTime final) 
        {
            if (inicial > final)
            {
                throw new Exception(String.Format("Exception: Data inicial deve ser anterior à data final do intervalo\nErro: {0} > {1}", inicial, final));
            }
            this.inicial = inicial;
            this.final = final;

            this.Duracao = this.final - this.inicial;
        }
        /*
         * Um intervalo X tem interseção com um intervalo Y
         * se X.final ou X.incio pertencem a [Y.incio, Y.final],
         * ou vice-versa
         */
        public bool TemIntersecao(Intervalo i)
        {
            return (this.inicial <= i.inicial && i.inicial <= this.final)
                || (this.inicial <= i.final && i.final <= this.final);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            var that = (Intervalo) obj;
            return this.inicial == that.inicial && this.final == that.final;
        }
        // Imprimir o intervalo no exercício 6
        public override string ToString()
            => $"{inicial} => {final}";
    }
}
