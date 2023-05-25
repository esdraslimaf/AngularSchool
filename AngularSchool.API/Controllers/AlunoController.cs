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
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public AlunoController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult PegarTodos()
        {
            var alunos = _repo.PegarTodosAlunos(true);
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }


        [HttpGet("{id}")]
        public IActionResult PegarPorId(int id)
        {
            var aluno = _repo.PegarAlunosPorId(id,true);
            if (aluno == null)
            {
                return BadRequest("Aluno inexistente");
            }
            return Ok(_mapper.Map<AlunoDto>(aluno));
        }

        [HttpGet("forr")]
        public IActionResult forr()
        {
            return Ok(new CadastraAlunoDto());
        }

        [HttpPost]
        public IActionResult AdicionarAluno([FromBody] CadastraAlunoDto alunodto)
        {
            var aluno = _mapper.Map<Aluno>(alunodto);

            _repo.Add(aluno);
            if (_repo.SaveChanges()) return Created($"/api/aluno/{alunodto.Id}", _mapper.Map<AlunoDto>(aluno));
            
            return BadRequest("Não foi possível adicionar o aluno!");
        }

        [HttpPut]
        public IActionResult AtualizarAlunoPut([FromBody] CadastraAlunoDto alunodto)
        {
            var Aluno = _repo.PegarAlunosPorId(alunodto.Id);

            if (Aluno == null) return BadRequest("Aluno não encontrado!");

            _mapper.Map(alunodto, Aluno);

            _repo.Update(Aluno);
            if (_repo.SaveChanges()) return Created($"/api/aluno/{alunodto.Id}", _mapper.Map<AlunoDto>(Aluno));
            else return BadRequest("Não foi possível atualizar o aluno!");
        }

        [HttpPatch]
        public IActionResult AtualizarAlunoPatch([FromBody] CadastraAlunoDto alunodto)
        {
            var Aluno = _repo.PegarAlunosPorId(alunodto.Id);

            if (Aluno == null) return BadRequest("Aluno não encontrado!");
            _mapper.Map(alunodto, Aluno);
            _repo.Update(Aluno);
            if (_repo.SaveChanges()) return Created($"/api/aluno/{alunodto.Id}", _mapper.Map<AlunoDto>(Aluno));
            else return BadRequest("Não foi possível atualizar o aluno!");
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
