using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex3
{
    internal class Turma
    {
        private readonly HashSet<Aluno> alunos = new();

        // Guardar todos os códigos de Turmas
        private static readonly HashSet<ulong> cods = new();

        // Backing Field
        private ulong _codigo;

        // O código passado (pelo construtor somente) deve ser único
        internal ulong Codigo { 
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

        internal Turma(ulong cod)
        {
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

        internal bool Contains(ulong matricula)
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
