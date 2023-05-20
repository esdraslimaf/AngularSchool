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

        public AlunoController(IRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public IActionResult PegarTodos()
        {
            return Ok(_repo.PegarTodosAlunos(true));
        }


        [HttpGet("{id}")]
        public IActionResult PegarPorId(int id)
        {
            var aluno = _repo.PegarAlunosPorId(id,true);
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
            var Aluno = _repo.PegarAlunosPorId(aluno.Id);
            if (Aluno == null) return BadRequest("Aluno não encontrado!");
            _repo.Update(aluno);
            if (_repo.SaveChanges()) return Ok(aluno);
            else return BadRequest("Não foi possível adicionar o aluno!");
        }

        [HttpPatch]
        public IActionResult AtualizarAlunoPatch([FromBody] Aluno aluno)
        {
            var Aluno = _repo.PegarAlunosPorId(aluno.Id);
            if (Aluno == null) return BadRequest("Aluno não encontrado!");
            _repo.Update(aluno);
            if (_repo.SaveChanges()) return Ok(aluno);
            else return BadRequest("Não foi possível adicionar o aluno!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarProfessor(int id)
        {
            var aluno = _repo.PegarAlunosPorId(id, false);
            if (aluno == null) return BadRequest("Aluno não encontrado!");
            _repo.Remove(aluno);
            if (_repo.SaveChanges()) return Ok("Removido"); //Remove essa e a próxima linha, pois são desnecessárias.
            else return BadRequest("Não foi possível remover o aluno!");
        }

    }
}
