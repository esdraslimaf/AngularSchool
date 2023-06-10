using AngularSchool.API.Database;
using AngularSchool.API.Helpers;
using AngularSchool.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularSchool.API.Repositories
{
    public class Repository : IRepository
    {
        private readonly SchoolContext _db;
        public Repository(SchoolContext db)
        {
            _db = db;
        }
        public void Add<T>(T Entity) where T : class
        {
            _db.Add(Entity);
        }
        public void Update<T>(T Entity) where T : class
        {
            _db.Update(Entity);
        }

        public void Remove<T>(T Entity) where T : class
        {
            _db.Remove(Entity);
        }  

        public bool SaveChanges()
        {
            return (_db.SaveChanges() > 0);
        }

        #region Implementação dos métodos de Alunos

        public async Task<PageList<Aluno>> PegarTodosAlunosAsync(PageParams pageParams, bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = _db.Alunos;
            if (incluirProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas).ThenInclude(ad => ad.Disciplina).ThenInclude(d => d.Professor);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id);
            // return await query.ToListAsync();

            if (!string.IsNullOrEmpty(pageParams.Nome))
            {
                query = query.Where(aluno => aluno.Nome.ToUpper().Contains(pageParams.Nome.ToUpper()) ||
                aluno.Sobrenome.ToUpper().Contains(pageParams.Nome.ToUpper()));
            }

            if (pageParams.Matricula > 0)
            {
                query = query.Where(aluno => aluno.Matricula == pageParams.Matricula);
            }

            if (pageParams.Ativo!=null)
            {
                query = query.Where(aluno => aluno.Ativo == (pageParams.Ativo != 0));
            }

            return await PageList<Aluno>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);

        }

        public Aluno[] PegarTodosAlunos(bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = _db.Alunos;
            if (incluirProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas).ThenInclude(ad=>ad.Disciplina).ThenInclude(d=>d.Professor);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id);
            return query.ToArray();

        }

        public Aluno[] PegarAlunosPorDisciplinaId(int disciplinaId, bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = _db.Alunos;
            if (incluirProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas).ThenInclude(ad => ad.Disciplina).ThenInclude(ad => ad.Professor);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id).Where(a => a.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId));

            return query.ToArray();
        }

        public Aluno PegarAlunosPorId(int alunoid, bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = _db.Alunos;
            if (incluirProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas).ThenInclude(ad => ad.Disciplina).ThenInclude(ad => ad.Professor);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id).Where(a=>a.Id==alunoid);

            return query.FirstOrDefault();
        }
        #endregion


        #region Implementação dos métodos de Professores
        public Professor[] PegarTodosProfessores(bool incluirAlunos = false)
        {
            IQueryable<Professor> query = _db.Professores;
            if (incluirAlunos)
            {
                query = query.Include(prof => prof.Disciplinas).ThenInclude(d => d.AlunosDisciplinas).ThenInclude(ad => ad.Aluno);
            }
            query = query.AsNoTracking().OrderBy(prof => prof.Id);
            return query.ToArray();
        } 
        public async Task<Professor[]> PegarTodosProfessoresAsync(bool incluirAlunos = false)
        {
            IQueryable<Professor> query = _db.Professores;
            if (incluirAlunos)
            {
                query = query.Include(prof => prof.Disciplinas).ThenInclude(d => d.AlunosDisciplinas).ThenInclude(ad => ad.Aluno);
            }
            query = query.AsNoTracking().OrderBy(prof => prof.Id);
            return await query.ToArrayAsync();
        }
        /* Quando o await é encontrado na linha return await query.ToArrayAsync();, a execução do método PegarTodosProfessoresAsync é pausada e a tarefa assíncrona retornada pelo método ToArrayAsync() é aguardada.
         * Durante esse tempo de espera, o fluxo do programa é liberado para executar outras tarefas. O controle é retornado ao chamador original do método PegarTodosProfessoresAsync, permitindo que ele execute outras operações simultaneamente.
         * Quando a operação assíncrona ToArrayAsync() é concluída e o array de professores é retornado, o fluxo do programa retorna ao ponto após o await e continua a execução a partir desse ponto. Nesse caso, o array de professores é retornado como resultado da tarefa assíncrona.
         * Em resumo, "aguardar a conclusão com o await" significa pausar a execução do método assíncrono e liberar a thread para executar outras tarefas enquanto a operação assíncrona está em andamento. O fluxo do programa retorna ao ponto após o await quando a operação é concluída, permitindo que a execução continue a partir desse ponto. Isso torna o programa mais responsivo e eficiente, pois outras tarefas podem ser executadas enquanto aguardamos a conclusão de operações assíncronas demoradas.
          ---------------
         * Mais comentários no controlador quando o método for chamado.
         */



        public Professor[] PegarProfessoresPorDisciplinaId(int disciplinaId, bool incluirAlunos = false) 
        {
            IQueryable<Professor> query = _db.Professores;
            if (incluirAlunos)
            {
                query = query.Include(prof => prof.Disciplinas).ThenInclude(dis => dis.AlunosDisciplinas).ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking().OrderBy(prof => prof.Id).Where(prof => prof.Disciplinas.Any(dis => dis.Id == disciplinaId));
            return query.ToArray();
        }

        public Professor PegarProfessoresPorId(int professorId, bool incluirAlunos=false)
        {
            IQueryable<Professor> query = _db.Professores;

            if (incluirAlunos)
            {
                query = query.Include(prof => prof.Disciplinas).ThenInclude(dis => dis.AlunosDisciplinas).ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking().Where(professor => professor.Id == professorId);
            return query.FirstOrDefault();
        }
        #endregion
    }
}
