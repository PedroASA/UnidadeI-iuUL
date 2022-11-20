using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex3
{
    internal class Turma
    {
        private readonly HashSet<Aluno> alunos = new();

        private static readonly HashSet<int> cods = new();

        // Backing Field
        private int _codigo;

        // Único
        internal int Codigo { 
            get => _codigo; 
            private set
            {
                if (cods.Contains(value))
                    throw new Exception("Código de Turma já registrado");
                _codigo = value;
            } 
        }

        internal int Count
        {
            private set { }
            get => alunos.Count;
        }

        internal Turma(int cod)
        {
            // Check Code
            // Generate Exception
            this.Codigo = cod;
        }

        public override int GetHashCode()
        {
            return Codigo.GetHashCode();
        }

        public static bool operator ==(Turma t1, Turma t2)
        {
            return t1.Codigo == t2.Codigo;
        }

        public static bool operator !=(Turma t1, Turma t2)
        {
            return !(t1 == t2);
        }

        public override bool Equals(object obj)
        {
            return obj is Turma turma && this == turma;
        }

        internal bool Contains(int matricula)
        {
            return alunos
                .Where(a => a.Matricula == matricula)
                .Count() == 1;
        }

        internal bool InserirAluno(Aluno a)
        {
            return alunos.Add(a);
        }

        internal bool RemoverAluno(Aluno a)
        {
            return alunos.Remove(a);
        }

        internal string Listar()
        {
            return alunos.OrderBy(x => x.Nome)
                .Aggregate($"Código da turma: {Codigo}\nAlunos:\n{"\tNome", -4}\t{"Matrícula", 10}", (acc, x) => acc + "\n" + x);
        }

        public override string ToString()
        {
            return Listar();
        }

    }
}
