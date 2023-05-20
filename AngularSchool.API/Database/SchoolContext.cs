using AngularSchool.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AngularSchool.API.Database
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }


        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }
        public DbSet<AlunoCurso> AlunosCursos { get; set; }
        public DbSet<Curso> Cursos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoDisciplina>().HasKey(ad => new { ad.AlunoId, ad.DisciplinaId });
            modelBuilder.Entity<AlunoCurso>().HasKey(ac => new { ac.AlunoId, ac.CursoId });

            modelBuilder.Entity<Professor>()
                .HasData(new List<Professor>(){
                     new Professor(1, 1, "John", "Doe"),
        new Professor(2, 2, "Jane", "Smith"),
        new Professor(3, 3, "Michael", "Johnson"),
        new Professor(4, 4, "Emily", "Davis"),
        new Professor(5, 5, "Daniel", "Wilson")
                });

            modelBuilder.Entity<Curso>()
                .HasData(new List<Curso>{
                    new Curso(1, "Engenharia de Software"),
        new Curso(2, "Análise e Desenvolvimento de Sistemas"),
        new Curso(3, "Ciências da Computação")
                });

            modelBuilder.Entity<Disciplina>()
                .HasData(new List<Disciplina>{
                    new Disciplina(1, "Cálculo", 1, 1),
                    new Disciplina(2, "Cálculo", 1, 3),
                    new Disciplina(3, "Gramática", 2, 3),
                    new Disciplina(4, "Português", 3, 1),
                    new Disciplina(5, "Programação I", 4, 1),
                    new Disciplina(6, "Programação I", 4, 2),
                    new Disciplina(7, "Mecânica Clássica", 4, 3),
                    new Disciplina(8, "Álgebra Linear", 5, 1),
                    new Disciplina(9, "Álgebra Linear", 5, 2),
                    new Disciplina(10, "Álgebra Linear", 5, 3)
                });

            modelBuilder.Entity<Aluno>()
    .HasData(new List<Aluno>(){
       new Aluno(1, 1, "Joana", "Silva", DateTime.Parse("01/10/2003"), "111111111"),
        new Aluno(2, 2, "Maria", "Santos", DateTime.Parse("02/15/2003"), "22222222"),
        new Aluno(3, 3, "Carolina", "Pereira", DateTime.Parse("03/20/2003"), "33333333"),
        new Aluno(4, 4, "Ana", "Lima", DateTime.Parse("04/25/2003"), "44444444"),
        new Aluno(5, 5, "Bruno", "Ferreira", DateTime.Parse("05/30/2003"), "5555555"),
        new Aluno(6, 6, "Rafael", "Martins", DateTime.Parse("06/05/2003"), "88888888"),
        new Aluno(7, 7, "Luciana", "Rodrigues", DateTime.Parse("07/10/2003"), "7777777")
    });

            modelBuilder.Entity<AlunoDisciplina>()
                .HasData(new List<AlunoDisciplina>() {
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 5 }
                });


        }


    }
}
