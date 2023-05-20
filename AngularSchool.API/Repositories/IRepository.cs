using AngularSchool.API.Models;

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
        Aluno[] PegarTodosAlunos(bool incluirProfessor);
        Aluno[] PegarAlunosPorDisciplinaId(int disciplinaId, bool incluirProfessor);
        Aluno PegarAlunosPorId(int alunoid, bool incluirProfessor = false);

        //Assinatura de métodos para professor
        Professor[] PegarTodosProfessores(bool incluirAlunos);
        Professor[] PegarProfessoresPorDisciplinaId(int disciplinaId, bool incluirAlunos);
        Professor PegarProfessoresPorId(int professorId, bool incluirAlunos);
    }
}
