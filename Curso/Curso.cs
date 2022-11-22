using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    internal class Curso
    {
        private readonly string nome;

        private readonly HashSet<Aluno> alunos = new();

        private readonly HashSet<Turma> turmas = new();

        internal Curso(string nome) 
        { 
            this.nome = nome;
        }

        // Adicionar um aluno já criado
        internal bool MatricularAluno(Aluno a)
        {
            return alunos.Add(a);
        }

        // Remover um aluno se estiver inscrito no curso 
        // e não estiver associado a nenhuma turma
        internal bool RemoverAluno(ulong matricula)
        {
            if (TryGetAluno(matricula, out Aluno _a))
            {
                if (turmas.All(t => !t.Contains(matricula)))
                {
                    return alunos.Remove(_a);
                }
            }
            return false;
        }

        // Inserir um aluno já inscrito no curso a uma turma do curso
        internal bool InserirAlunoTurma(ulong codigo, ulong matricula)
        {
            if (TryGetTurma(codigo, out Turma _t))
            {
                if (TryGetAluno(matricula, out Aluno _a))
                    return _t.InserirAluno(_a);
            }
            return false;
        }

        // Remover aluno já inscrito no curso de uma turma do curso
        internal bool RemoverAlunoTurma(ulong codigo, ulong matricula)
        {
            if (TryGetTurma(codigo, out Turma _t))
            {
                if (TryGetAluno(matricula, out Aluno _a))
                {
                    return _t.RemoverAluno(_a);
                }
            }
            return false;
        }

        // Cria Turma do zero
        internal bool CriarTurma(ulong codigo)
        {
            return turmas.Add(new Turma(codigo));
        }

        // Remover uma turma do curso, se ela estiver inscrita no curso
        // e nenhum aluno estiver inscrito nela
        internal bool RemoverTurma(ulong codigo)
        {

            if (TryGetTurma(codigo, out Turma _t))
            {
                if(_t.Count == 0)
                    return turmas.Remove(_t);
            }
            return false;
        }

        // Listar alunos de uma turma
        internal string ListarTurma(ulong codigo)
        {

            if (TryGetTurma(codigo, out Turma _t))
            {
                return _t.Listar();
            }
            return "Turma não inscrita no Curso";
        }

        // Listar turmas não vazias do curso
        internal string Listar()
        {
            return turmas.Where(x => x.Count != 0)
                .OrderBy(x=> x.Codigo)
                .Aggregate($"\n\nTurmas do curso {nome}:\n", (acc,e) => acc + "\n" + e + "\n");
        }

        private bool TryGetAluno(ulong matricula, out Aluno a)
        {
            var t = alunos.Where(a => a.Matricula == matricula);
            if (t.Count() == 1)
            {
                a = t.First();
                return true;
            }
            a = null;
            return false;


        }

        private bool TryGetTurma(ulong codigo, out Turma t)
        {
            var tmp = turmas.Where(_t => _t.Codigo == codigo);
            if (tmp.Count() == 1)
            {
                t = tmp.First();
                return true;
            }
            t = null;
            return false;
        }
    }
}
