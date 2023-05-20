using AngularSchool.API.Database;
using AngularSchool.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
