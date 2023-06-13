using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularSchool.API.Migrations
{
    public partial class iniciarMySql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Registro = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    CargaHoraria = table.Column<int>(nullable: false),
                    PrerequisitoId = table.Column<int>(nullable: true),
                    CursoId = table.Column<int>(nullable: false),
                    ProfessorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PrerequisitoId",
                        column: x => x.PrerequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    Nota = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "DataNascimento", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2023, 6, 12, 23, 19, 6, 957, DateTimeKind.Local).AddTicks(3711), new DateTime(2003, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Joana", "Silva", "111111111" },
                    { 2, true, null, new DateTime(2023, 6, 12, 23, 19, 6, 957, DateTimeKind.Local).AddTicks(7265), new DateTime(2003, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Maria", "Santos", "22222222" },
                    { 3, true, null, new DateTime(2023, 6, 12, 23, 19, 6, 957, DateTimeKind.Local).AddTicks(7357), new DateTime(2003, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Carolina", "Pereira", "33333333" },
                    { 4, true, null, new DateTime(2023, 6, 12, 23, 19, 6, 957, DateTimeKind.Local).AddTicks(7369), new DateTime(2003, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Ana", "Lima", "44444444" },
                    { 5, true, null, new DateTime(2023, 6, 12, 23, 19, 6, 957, DateTimeKind.Local).AddTicks(7377), new DateTime(2003, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Bruno", "Ferreira", "5555555" },
                    { 6, true, null, new DateTime(2023, 6, 12, 23, 19, 6, 957, DateTimeKind.Local).AddTicks(7395), new DateTime(2003, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Rafael", "Martins", "88888888" },
                    { 7, true, null, new DateTime(2023, 6, 12, 23, 19, 6, 957, DateTimeKind.Local).AddTicks(7404), new DateTime(2003, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Luciana", "Rodrigues", "7777777" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Engenharia de Software" },
                    { 2, "Análise e Desenvolvimento de Sistemas" },
                    { 3, "Ciências da Computação" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2023, 6, 12, 23, 19, 6, 823, DateTimeKind.Local).AddTicks(3415), "John", 1, "Doe", null },
                    { 2, true, null, new DateTime(2023, 6, 12, 23, 19, 6, 825, DateTimeKind.Local).AddTicks(5454), "Jane", 2, "Smith", null },
                    { 3, true, null, new DateTime(2023, 6, 12, 23, 19, 6, 825, DateTimeKind.Local).AddTicks(5572), "Michael", 3, "Johnson", null },
                    { 4, true, null, new DateTime(2023, 6, 12, 23, 19, 6, 825, DateTimeKind.Local).AddTicks(5575), "Emily", 4, "Davis", null },
                    { 5, true, null, new DateTime(2023, 6, 12, 23, 19, 6, 825, DateTimeKind.Local).AddTicks(5577), "Daniel", 5, "Wilson", null }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[,]
                {
                    { 1, 0, 1, "Cálculo", null, 1 },
                    { 2, 0, 3, "Cálculo", null, 1 },
                    { 3, 0, 3, "Gramática", null, 2 },
                    { 4, 0, 1, "Português", null, 3 },
                    { 5, 0, 1, "Programação I", null, 4 },
                    { 6, 0, 2, "Programação I", null, 4 },
                    { 7, 0, 3, "Mecânica Clássica", null, 4 },
                    { 8, 0, 1, "Álgebra Linear", null, 5 },
                    { 9, 0, 2, "Álgebra Linear", null, 5 },
                    { 10, 0, 3, "Álgebra Linear", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(829), null },
                    { 4, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(849), null },
                    { 2, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(836), null },
                    { 1, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(826), null },
                    { 7, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(867), null },
                    { 6, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(860), null },
                    { 5, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(850), null },
                    { 4, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(847), null },
                    { 1, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(792), null },
                    { 7, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(865), null },
                    { 5, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(852), null },
                    { 6, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(857), null },
                    { 7, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(863), null },
                    { 6, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(855), null },
                    { 3, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(840), null },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(831), null },
                    { 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 957, DateTimeKind.Local).AddTicks(9889), null },
                    { 7, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(862), null },
                    { 6, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(853), null },
                    { 4, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(845), null },
                    { 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(838), null },
                    { 3, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(841), null },
                    { 7, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 12, 23, 19, 6, 958, DateTimeKind.Local).AddTicks(868), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_CursoId",
                table: "AlunosCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PrerequisitoId",
                table: "Disciplinas",
                column: "PrerequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCursos");

            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
