using AngularSchool.API.Database;
using AngularSchool.API.Dtos;
using AngularSchool.API.Models;
using AngularSchool.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AngularSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult PegarProfessores()
        {
            var alunos = _repo.PegarTodosProfessores(true);
            return Ok(_mapper.Map<ICollection<ProfessorDto>>(alunos));
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
                return BadRequest("Professor inexistente");
            }
            return Ok(_mapper.Map<ProfessorDto>(professor));
        }

        [HttpGet("forr")]
        public IActionResult forr()
        {
            return Ok(new CadastraProfessorDto());
        }

        [HttpPost]
        public IActionResult AdicionarProfessor([FromBody] CadastraProfessorDto CadProfessorDto)
        {
            var professor = _mapper.Map<Professor>(CadProfessorDto);
            _repo.Add(professor);
            if (_repo.SaveChanges()) return Created($"/api/professor/{CadProfessorDto.Id}", _mapper.Map<ProfessorDto>(professor));
            else return BadRequest("Não foi possível adicionar o professor!");
        }
        [HttpPut]
        public IActionResult AtualizarProfessorPut([FromBody] CadastraProfessorDto CadProfessorDto)
        {
            var Professor = _repo.PegarProfessoresPorId(CadProfessorDto.Id, false);
            if (Professor == null) return BadRequest("Professor não encontrado!");

            _mapper.Map(CadProfessorDto,Professor);

            _repo.Update(Professor);

            if (_repo.SaveChanges()) return Created($"/api/professor/{CadProfessorDto.Id}", _mapper.Map<ProfessorDto>(Professor));
            else return BadRequest("Não foi possível adicionar o professor!");
        }

        [HttpPatch]
        public IActionResult AtualizarProfessorPatch([FromBody] CadastraProfessorDto CadProfessorDto)
        {
            var Professor = _repo.PegarProfessoresPorId(CadProfessorDto.Id, false);
            if (Professor == null) return BadRequest("Professor não encontrado!");
            _repo.Update(Professor);
            if (_repo.SaveChanges()) return Created($"/api/professor/{CadProfessorDto.Id}", _mapper.Map<ProfessorDto>(Professor));
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
