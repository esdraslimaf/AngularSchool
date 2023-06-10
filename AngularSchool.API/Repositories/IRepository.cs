using AngularSchool.API.Helpers;
using AngularSchool.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularSchool.API.Repositories
{
    public interface IRepository
    {
        //Métodos compartilhados
        void Add<T>(T Entity) where T:class; //Tipo genérico. Adiciona um tipo T, recebendo um tipo T, onde T é um tipo classe
        void Remove<T>(T Entity) where T : class;
        void Update<T>(T Entity) where T:class;
        bool SaveChanges();

        //Assinatura de métodos para aluno 
        Task<PageList<Aluno>> PegarTodosAlunosAsync(PageParams pageParams, bool incluirProfessor = false);
        Aluno[] PegarAlunosPorDisciplinaId(int disciplinaId, bool incluirProfessor);
        Aluno PegarAlunosPorId(int alunoid, bool incluirProfessor = false);

        //Assinatura de métodos para professor
        Task<Professor[]> PegarTodosProfessoresAsync(bool incluirAlunos = false);
        Professor[] PegarTodosProfessores(bool incluirAlunos = false);
        Professor[] PegarProfessoresPorDisciplinaId(int disciplinaId, bool incluirAlunos);
        Professor PegarProfessoresPorId(int professorId, bool incluirAlunos);
    }
}
