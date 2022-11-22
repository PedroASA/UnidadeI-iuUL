using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex3
{
    internal class Aluno
    {
        internal string Nome { get; private set; }

        // Contador para gerar matrícula única
        private static ulong cnt = 0;

        internal ulong Matricula { get; private set; }

        internal Turma _turma = null;

        internal Turma Turma 
        { 
            get => _turma; 
            set
            {
                if (_turma is null || value is null)
                {
                    _turma = value;
                }
                else throw new Exception("Aluno não pode estar em duas turmas");
            }
        }

        private static ulong GetMatricula()
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
