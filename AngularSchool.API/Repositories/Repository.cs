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
        public Aluno[] PegarTodosAlunos(bool incluirDisciplina)
        {
            IQueryable<Aluno> query = _db.Alunos;
            if (incluirDisciplina)
            {
                query = query.Include(a => a.AlunosDisciplinas).ThenInclude(ad => ad.Disciplina).ThenInclude(ad => ad.Professor);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id);
            return query.ToArray();

        }

        public Aluno[] PegarAlunosPorDisciplinaId()
        {
            throw new System.NotImplementedException();
        }

        public Aluno[] PegarAlunosPorId()
        {
            throw new System.NotImplementedException();
        }
        #endregion


        #region Implementação dos métodos de Professores
        public Professor[] PegarTodosProfessores()
        {
            throw new System.NotImplementedException();
        }

        public Professor[] PegarProfessoresPorDisciplinaId()
        {
            throw new System.NotImplementedException();
        }

        public Professor[] PegarProfessoresPorId()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
