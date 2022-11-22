using System;

namespace Ex2
{
    // Assume que um aluno só pode estar em uma turma
    internal class Aluno
    {
        internal readonly string matricula, nome;

        internal float NotaP1 { get; set; }

        internal float NotaP2 { get; set; }

        internal float NotaFinal
        {
            get => (NotaP1 + NotaP2) / 2;

            private set { }
        }

        internal Aluno(string nome, string matricula)
        {
            this.nome = nome;
            this.matricula = matricula;
        }

        public override bool Equals(object obj)
        {
            return obj is Aluno aluno && this == aluno;
        }

        public static bool operator ==(Aluno al1, Aluno al2)
        {
            return (al1.nome, al1.matricula) == (al2.nome, al2.matricula);
        }

        public static bool operator !=(Aluno al1, Aluno al2)
        {
            return !(al1==al2);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(nome, matricula);
        }
        public override string ToString()
        {
            return $"| {nome, -25} | {matricula, -10} | {NotaP1, 5} | {NotaP2, 10} | {NotaFinal, 15} |";
        }
    }
}
