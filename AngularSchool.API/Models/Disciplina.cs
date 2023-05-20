using System.Collections.Generic;

namespace AngularSchool.API.Models
{
    public class Disciplina
    {
        public Disciplina()
        {

        }

        public Disciplina(int id, string nome, int professorId, int cursoId)
        {
            Id = id;
            Nome = nome;
            ProfessorId = professorId;
            CursoId = cursoId;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public int? PrerequisitoId { get; set; } = null; //Podemos colocar um valor aqui como FK de algum outra disciplina("Pra fazer uma disciplina tem que ter feito outra", a lógica é meio que essa).
        public Disciplina Prerequisito { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}
