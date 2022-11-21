using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Ex2
{
    // Assume que um aluno só pode estar em uma turma
    internal class Turma
    {
        private readonly HashSet<Aluno> alunos = new ();

        // Medias de P1, P2 e Final
        private (float, float, float) Avgs
        {
            set { }

            get 
            {
                var t = alunos.Aggregate((0f, 0f, 0f),
                (acc, x) =>
                (acc.Item1 + x.NotaP1,
                acc.Item2 + x.NotaP2,
                acc.Item3 + x.NotaFinal));

                var n = alunos.Count;

                return (t.Item1 / n, t.Item2 / n, t.Item3 / n);
            }
        }

        // Aluno com maior nota final
        private Aluno Best
        {
            set { }

            get => alunos
                .Aggregate(alunos.First(),
                (acc, x) => acc.NotaFinal > x.NotaFinal ? acc : x);
        }

        internal bool Add(Aluno aluno)
        {
            return alunos.Add(aluno);
        }

        internal bool Remove(Aluno aluno)
        {
            return alunos.Remove(aluno);
        }

        internal bool PutP1(Aluno aluno, float nota)
        {
            if (alunos.TryGetValue(aluno, out aluno))
            {
                aluno.NotaP1 = nota;
                return true;
            }
            return false;
        }

        internal bool PutP2(Aluno aluno, float nota)
        {
            if (alunos.TryGetValue(aluno, out aluno))
            {
                aluno.NotaP2 = nota;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return alunos
                .OrderBy(x => x.nome)
                .Aggregate($"| {"Nome", -25} | {"Matricula", -10} | {"P1", 5} | {"P2", 10} | {"NF", 15} |\n", (acc, x) => acc + "\n" + x);
        }

        internal void PrintTurma()
        {
            Console.WriteLine(this);
        }

        internal void PrintStatistics()
        {
            var t = Avgs;

            Console.WriteLine("\nMédias:");
            Console.WriteLine($"\n| {"Média P1",-10} | {"Média P2",10} | {"Média Final",15} |");
            Console.WriteLine($"| {t.Item1,-10} | {t.Item2,10} | {t.Item3,15} |");

            Console.WriteLine("\nMelhor Aluno:");
            Console.WriteLine($"| {"Nome",-25} | {"Matricula",-10} | {"P1",5} | {"P2",10} | {"NF",15} |\n");
            Console.WriteLine(Best);

        }
    }
}
