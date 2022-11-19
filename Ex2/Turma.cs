using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    internal class Turma
    {
        private readonly List<Aluno> alunos = new List<Aluno>();

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

        private Aluno Best
        {
            set { }

            get => alunos
                .Aggregate(alunos.First(),
                (acc, x) => acc.NotaFinal > x.NotaFinal ? acc : x);


        }

        internal bool Add(Aluno aluno)
        {
            if (!alunos.Contains(aluno))
            {
                alunos.Add(aluno);
                return true;
            }
            return false;
        }

        internal bool Remove(Aluno aluno)
        {
            if (alunos.Contains(aluno))
            {
                alunos.Remove(aluno);
                return true;
            }
            return false;
        }

        internal bool PutP1(Aluno aluno, float nota)
        {
            if (alunos.Contains(aluno))
            {
                alunos.Where(x => x == aluno).First()
                    .NotaP1 = nota;
                return true;
            }
            return false;
        }

        internal bool PutP2(Aluno aluno, float nota)
        {
            if (alunos.Contains(aluno))
            {
                alunos.Where(x => x == aluno).First()
                    .NotaP2 = nota;
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
            Console.WriteLine($"| {"Nome",-25} | {"Matricula",-10} | {"P1",5} | {"P2",10} | {"NF",15} |");
            Console.WriteLine(Best);

        }
    }
}
