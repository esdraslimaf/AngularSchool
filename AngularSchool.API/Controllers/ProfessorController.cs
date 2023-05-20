using AngularSchool.API.Database;
using AngularSchool.API.Models;
using AngularSchool.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AngularSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult PegarProfessores()
        {
            return Ok(_repo.PegarTodosProfessores(true));
        }

        /*   [HttpGet("PegarPorNome")] //Usar QueryString para treinar
           public IActionResult PegarPorNome(string nome)
           {
               var professor = _db.Professores.FirstOrDefault(a => a.Nome.Contains(nome));
               if (professor == null)
               {
                   return BadRequest("professor inexistente");
               }
               return Ok(professor);
           }
        */

        [HttpGet("{id}")]
        public IActionResult PegarPorId(int id)
        {
            var professor = _repo.PegarProfessoresPorId(id, true);
            if (professor == null)
            {
                return BadRequest("professor inexistente");
            }
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult AdicionarProfessor([FromBody] Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges()) return Ok(professor);
            else return BadRequest("Não foi possível adicionar o professor!");
        }
        [HttpPut]
        public IActionResult AtualizarProfessorPut([FromBody] Professor professor)
        {
            var Professor = _repo.PegarProfessoresPorId(professor.Id, false);
            if (Professor == null) return BadRequest("Professor não encontrado!");
            _repo.Update(professor);
            if (_repo.SaveChanges()) return Ok(professor);
            else return BadRequest("Não foi possível adicionar o professor!");
        }

        [HttpPatch]
        public IActionResult AtualizarProfessorPatch([FromBody] Professor professor)
        {
            var Professor = _repo.PegarProfessoresPorId(professor.Id, false);
            if (Professor == null) return BadRequest("Professor não encontrado!");
            _repo.Update(professor);
            if (_repo.SaveChanges()) return Ok(professor);
            else return BadRequest("Não foi possível adicionar o professor!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarProfessor(int id)
        {
            var professor = _repo.PegarProfessoresPorId(id, false);
            if (professor == null) return BadRequest("Professor não encontrado!");
            _repo.Remove(professor);
            if (_repo.SaveChanges()) return Ok("Removido!"); //Remove essa e a próxima linha, pois são desnecessárias.
            else return BadRequest("Não foi possível remover o professor!");
        }

    }
}
