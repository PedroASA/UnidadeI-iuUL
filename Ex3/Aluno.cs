using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex3
{
    internal class Aluno
    {
        internal string Nome { get; private set; }

        private static int cnt = 0;

        internal int Matricula { get; private set; }

        internal Turma turma { get; set; }

        private static int GetMatricula()
        {
            return cnt++;
        }

        internal Aluno(string nome)
        {
            this.Nome = nome;
            this.Matricula = GetMatricula();
        }

        public override int GetHashCode()
        {
            return Matricula.GetHashCode();
        }

        public static bool operator ==(Aluno al1, Aluno al2)
        {
            return al1.Matricula == al2.Matricula;
        }

        public static bool operator !=(Aluno al1, Aluno al2)
        {
            return !(al1 == al2);
        }

        public override bool Equals(object obj)
        {
            return obj is Aluno aluno && this == aluno;
        }

        public override string ToString()
        {
            return $"\t{Nome,-4}\t{Matricula, 10}";
        }
    }
}
