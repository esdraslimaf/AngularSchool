using AngularSchool.API.Database;
using AngularSchool.API.Dtos;
using AngularSchool.API.Extensions;
using AngularSchool.API.Helpers;
using AngularSchool.API.Models;
using AngularSchool.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularSchool.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public AlunoController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Método para buscar todos os alunos no banco de dados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> PegarTodos([FromQuery]PageParams pageParams)
        {
            var alunos = await _repo.PegarTodosAlunosAsync(pageParams,true);
            
            var alunosConvertidosDto = _mapper.Map<IEnumerable<AlunoDto>>(alunos);

            Response.AddPagination(alunos.PaginaAtual,alunos.TamanhoDasPaginas, alunos.ItensTotal,alunos.TotalDePaginas);

            return Ok(alunosConvertidosDto);
        }

        /// <summary>
        /// Método para buscar apenas um único Aluno no banco e convertê-lo para AlunoDto.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Formato do JSON para cadastrar aluno
        /// </summary>
        /// <returns></returns>
        [HttpGet("forr")]
        public IActionResult forr()
        {
            return Ok(new CadastraAlunoDto());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Cadalunodto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AdicionarAluno([FromBody] CadastraAlunoDto Cadalunodto)
        {
            var aluno = _mapper.Map<Aluno>(Cadalunodto);

            _repo.Add(aluno);
            if (_repo.SaveChanges()) return Created($"/api/aluno/{Cadalunodto.Id}", _mapper.Map<AlunoDto>(aluno));
            
            return BadRequest("Não foi possível adicionar o aluno!");
        }

        [HttpPut]
        public IActionResult AtualizarAlunoPut([FromBody] CadastraAlunoDto Cadalunodto)
        {
            var Aluno = _repo.PegarAlunosPorId(Cadalunodto.Id);

            if (Aluno == null) return BadRequest("Aluno não encontrado!");

            _mapper.Map(Cadalunodto, Aluno);

            _repo.Update(Aluno);
            if (_repo.SaveChanges()) return Created($"/api/aluno/{Cadalunodto.Id}", _mapper.Map<AlunoDto>(Aluno));
            else return BadRequest("Não foi possível atualizar o aluno!");
        }

        [HttpPatch]
        public IActionResult AtualizarAlunoPatch([FromBody] CadastraAlunoDto Cadalunodto)
        {
            var Aluno = _repo.PegarAlunosPorId(Cadalunodto.Id);

            if (Aluno == null) return BadRequest("Aluno não encontrado!");
            _mapper.Map(Cadalunodto, Aluno);
            _repo.Update(Aluno);
            if (_repo.SaveChanges()) return Created($"/api/aluno/{Cadalunodto.Id}", _mapper.Map<AlunoDto>(Aluno));
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
