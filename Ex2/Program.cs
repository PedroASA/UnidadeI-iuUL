using System;

namespace Ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Turma t = new();
            t.Add(new Aluno("Nome1", "mat1"));
            t.Add(new Aluno("Nome4", "mat4"));
            t.Add(new Aluno("Nome2", "mat2"));
            t.Add(new Aluno("Nome3", "mat3"));
            t.Add(new Aluno("Nome6", "mat6"));
            t.Add(new Aluno("Nome5", "mat5"));

            t.Remove(new Aluno("Nome5", "mat5"));

            t.PutP1(new Aluno("Nome1", "mat1"), 10f);
            t.PutP2(new Aluno("Nome1", "mat1"), 10f);

            t.PutP1(new Aluno("", "mat2"), 9.7f);
            t.PutP2(new Aluno("", "mat2"), 1.5f);

            t.PutP1(new Aluno("", "mat3"), 5.3f);
            t.PutP2(new Aluno("", "mat3"), 5.7f);

            t.PutP1(new Aluno("", "mat4"), 3.0f);
            t.PutP2(new Aluno("", "mat4"), 5.0f);

            t.PutP1(new Aluno("", "mat6"), 8.0f);
            t.PutP2(new Aluno("", "mat6"), 8.0f);

            t.PrintTurma();

            t.PrintStatistics();
        }
    }
}
