using System;

namespace AngularSchool.API.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina()
        {

        }

        public AlunoDisciplina(int alunoId, int disciplinaId)
        {
            Aluno.Id = alunoId;
            DisciplinaId = disciplinaId;
        }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime DataFim { get; set; }
        public double? Nota { get; set; } = null;
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }

    }
}
