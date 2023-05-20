using System;
using System.Collections.Generic;

namespace AngularSchool.API.Models
{
    public class Aluno
    {
        public Aluno()
        {

        }
        public Aluno(int id, int matricula, string nome, string sobrenome,DateTime datanascimento, string telefone)
        {
            Id = id;
            Matricula = matricula;
            Nome = nome;
            Sobrenome = sobrenome;            
            DataNascimento = datanascimento;
            Telefone = telefone;
        }

        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true; // Sempre que criar um aluno, ele automaticamente recebe true
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}
