﻿// <auto-generated />
using System;
using AngularSchool.API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AngularSchool.API.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20230520013854_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("AngularSchool.API.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<int>("Matricula")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 557, DateTimeKind.Local).AddTicks(4822),
                            DataNascimento = new DateTime(2003, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 1,
                            Nome = "Joana",
                            Sobrenome = "Silva",
                            Telefone = "111111111"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 557, DateTimeKind.Local).AddTicks(7794),
                            DataNascimento = new DateTime(2003, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 2,
                            Nome = "Maria",
                            Sobrenome = "Santos",
                            Telefone = "22222222"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 557, DateTimeKind.Local).AddTicks(7864),
                            DataNascimento = new DateTime(2003, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 3,
                            Nome = "Carolina",
                            Sobrenome = "Pereira",
                            Telefone = "33333333"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 557, DateTimeKind.Local).AddTicks(7873),
                            DataNascimento = new DateTime(2003, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 4,
                            Nome = "Ana",
                            Sobrenome = "Lima",
                            Telefone = "44444444"
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 557, DateTimeKind.Local).AddTicks(7879),
                            DataNascimento = new DateTime(2003, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 5,
                            Nome = "Bruno",
                            Sobrenome = "Ferreira",
                            Telefone = "5555555"
                        },
                        new
                        {
                            Id = 6,
                            Ativo = true,
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 557, DateTimeKind.Local).AddTicks(7893),
                            DataNascimento = new DateTime(2003, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 6,
                            Nome = "Rafael",
                            Sobrenome = "Martins",
                            Telefone = "88888888"
                        },
                        new
                        {
                            Id = 7,
                            Ativo = true,
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 557, DateTimeKind.Local).AddTicks(7899),
                            DataNascimento = new DateTime(2003, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 7,
                            Nome = "Luciana",
                            Sobrenome = "Rodrigues",
                            Telefone = "7777777"
                        });
                });

            modelBuilder.Entity("AngularSchool.API.Models.AlunoCurso", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CursoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.HasKey("AlunoId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("AlunosCursos");
                });

            modelBuilder.Entity("AngularSchool.API.Models.AlunoDisciplina", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Nota")
                        .HasColumnType("REAL");

                    b.HasKey("AlunoId", "DisciplinaId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("AlunosDisciplinas");

                    b.HasData(
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 2,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 557, DateTimeKind.Local).AddTicks(9799)
                        },
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 4,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(654)
                        },
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 5,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(695)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 1,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(698)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 2,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(700)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 5,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(705)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 1,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(707)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 2,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(708)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 3,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(710)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 1,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(713)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 4,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(715)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 5,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(717)
                        },
                        new
                        {
                            AlunoId = 5,
                            DisciplinaId = 4,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(718)
                        },
                        new
                        {
                            AlunoId = 5,
                            DisciplinaId = 5,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(720)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 1,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(722)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 2,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(723)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 3,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(725)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 4,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(728)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 1,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(729)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 2,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(731)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 3,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(733)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 4,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(734)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 5,
                            DataFim = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 558, DateTimeKind.Local).AddTicks(736)
                        });
                });

            modelBuilder.Entity("AngularSchool.API.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cursos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Engenharia de Software"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Análise e Desenvolvimento de Sistemas"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Ciências da Computação"
                        });
                });

            modelBuilder.Entity("AngularSchool.API.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CursoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PrerequisitoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("PrerequisitoId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Disciplinas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Nome = "Cálculo",
                            ProfessorId = 1
                        },
                        new
                        {
                            Id = 2,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Nome = "Cálculo",
                            ProfessorId = 1
                        },
                        new
                        {
                            Id = 3,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Nome = "Gramática",
                            ProfessorId = 2
                        },
                        new
                        {
                            Id = 4,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Nome = "Português",
                            ProfessorId = 3
                        },
                        new
                        {
                            Id = 5,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Nome = "Programação I",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 6,
                            CargaHoraria = 0,
                            CursoId = 2,
                            Nome = "Programação I",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 7,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Nome = "Mecânica Clássica",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 8,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Nome = "Álgebra Linear",
                            ProfessorId = 5
                        },
                        new
                        {
                            Id = 9,
                            CargaHoraria = 0,
                            CursoId = 2,
                            Nome = "Álgebra Linear",
                            ProfessorId = 5
                        },
                        new
                        {
                            Id = 10,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Nome = "Álgebra Linear",
                            ProfessorId = 5
                        });
                });

            modelBuilder.Entity("AngularSchool.API.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("Registro")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 551, DateTimeKind.Local).AddTicks(3684),
                            Nome = "John",
                            Registro = 1,
                            Sobrenome = "Doe"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 552, DateTimeKind.Local).AddTicks(8049),
                            Nome = "Jane",
                            Registro = 2,
                            Sobrenome = "Smith"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 552, DateTimeKind.Local).AddTicks(8124),
                            Nome = "Michael",
                            Registro = 3,
                            Sobrenome = "Johnson"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 552, DateTimeKind.Local).AddTicks(8129),
                            Nome = "Emily",
                            Registro = 4,
                            Sobrenome = "Davis"
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            DataInicio = new DateTime(2023, 5, 19, 22, 38, 53, 552, DateTimeKind.Local).AddTicks(8130),
                            Nome = "Daniel",
                            Registro = 5,
                            Sobrenome = "Wilson"
                        });
                });

            modelBuilder.Entity("AngularSchool.API.Models.AlunoCurso", b =>
                {
                    b.HasOne("AngularSchool.API.Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AngularSchool.API.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AngularSchool.API.Models.AlunoDisciplina", b =>
                {
                    b.HasOne("AngularSchool.API.Models.Aluno", "Aluno")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AngularSchool.API.Models.Disciplina", "Disciplina")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AngularSchool.API.Models.Disciplina", b =>
                {
                    b.HasOne("AngularSchool.API.Models.Curso", "Curso")
                        .WithMany("Disciplinas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AngularSchool.API.Models.Disciplina", "Prerequisito")
                        .WithMany()
                        .HasForeignKey("PrerequisitoId");

                    b.HasOne("AngularSchool.API.Models.Professor", "Professor")
                        .WithMany("Disciplinas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}