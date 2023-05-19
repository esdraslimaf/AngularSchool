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
        Aluno[] PegarTodosAlunos(bool incluirDisciplina);
        Aluno[] PegarAlunosPorDisciplinaId();
        Aluno[] PegarAlunosPorId();

        //Assinatura de métodos para professor
        Professor[] PegarTodosProfessores();
        Professor[] PegarProfessoresPorDisciplinaId();
        Professor[] PegarProfessoresPorId();
    }
}
