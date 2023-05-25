﻿using System;

namespace AngularSchool.API.Dtos
{
    public class AlunoDto
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Telefone { get; set; }
        //public DateTime DataNascimento { get; set; }
        public DateTime DataInicio { get; set; }
        //public DateTime? DataFim { get; set; }
        public bool Ativo { get; set; }
        
    }
}
