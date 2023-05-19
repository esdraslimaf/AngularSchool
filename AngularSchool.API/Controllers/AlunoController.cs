using AngularSchool.API.Database;
using AngularSchool.API.Models;
using AngularSchool.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AngularSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly SchoolContext _db;
        public AlunoController(IRepository repo, SchoolContext db)
        {
            _repo = repo;
            _db = db;
        }

        [HttpGet]
        public IActionResult PegarTodos()
        {
            return Ok(_db.Alunos.ToList());
        }

        [HttpGet("PegarPorNome")] //Usar QueryString para treinar
        public IActionResult PegarPorNome(string nome, string sobrenome)
        { 

            var aluno = _db.Alunos.FirstOrDefault(a=>a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null)
            {
                return BadRequest("Aluno inexistente");
            }
            return Ok(aluno);
        }

        [HttpGet("pegarporid/{id}")]
        public IActionResult PegarPorId(int id)
        {
            var aluno = _db.Alunos.Include(a=>a.AlunosDisciplinas).FirstOrDefault(a=>a.Id==id);
            if (aluno == null)
            {
                return BadRequest("Aluno inexistente");
            }
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult AdicionarAluno([FromBody]Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges()) return Ok(aluno);
            else return BadRequest("Não foi possível adicionar o aluno!");
        }

        [HttpPut]
        public IActionResult AtualizarAlunoPut([FromBody] Aluno aluno)
        {
            var Aluno = _db.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == aluno.Id);
            if (Aluno == null) return BadRequest("Aluno não encontrado!");
            _repo.Update(aluno);
            if (_repo.SaveChanges()) return Ok(aluno);
            else return BadRequest("Não foi possível adicionar o aluno!");
        }

        [HttpPatch]
        public IActionResult AtualizarAlunoPatch([FromBody] Aluno aluno)
        {
            var Aluno = _db.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == aluno.Id);
            if (Aluno == null) return BadRequest("Aluno não encontrado!");
            _repo.Update(aluno);
            if (_repo.SaveChanges()) return Ok(aluno);
            else return BadRequest("Não foi possível adicionar o aluno!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarProfessor(int id)
        {
            var aluno = _db.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado!");
            _repo.Remove(aluno);
            if (_repo.SaveChanges()) return Ok("Removido"); //Remove essa e a próxima linha, pois são desnecessárias.
            else return BadRequest("Não foi possível remover o aluno!");
        }

    }
}
