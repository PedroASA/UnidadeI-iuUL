using System;

namespace Ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Curso c = new("Curso1");

            c.MatricularAluno(new Aluno("Aluno0"));
            c.MatricularAluno(new Aluno("Aluno1"));
            c.MatricularAluno(new Aluno("Aluno2"));
            c.MatricularAluno(new Aluno("Aluno3"));
            c.MatricularAluno(new Aluno("Aluno4"));
            c.MatricularAluno(new Aluno("Aluno5"));
            c.MatricularAluno(new Aluno("Aluno6"));
            c.MatricularAluno(new Aluno("Aluno7"));

            c.RemoverAluno(5);

            c.CriarTurma(1);
            c.CriarTurma(2);
            c.CriarTurma(3);

            c.RemoverTurma(2);

            c.InserirAlunoTurma(1, 7);
            c.InserirAlunoTurma(1, 1);
            c.InserirAlunoTurma(1, 3);

            c.InserirAlunoTurma(3, 5);
            c.InserirAlunoTurma(3, 4);
            c.InserirAlunoTurma(3, 2);
            c.InserirAlunoTurma(3, 0);
            try
            {
                c.InserirAlunoTurma(3, 3);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }


            c.RemoverAlunoTurma(3, 2);

            Console.WriteLine(c.ListarTurma(1));

            Console.WriteLine(c.Listar());
        }
    }
}
