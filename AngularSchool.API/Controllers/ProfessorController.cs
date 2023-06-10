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
using System.Threading.Tasks;

namespace AngularSchool.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
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
        public async Task<IActionResult> PegarProfessores()
        {
            var professores = await _repo.PegarTodosProfessoresAsync(true);
            return Ok(_mapper.Map<ICollection<ProfessorDto>>(professores));
        }
        /* Quando usamos o await para chamar um método assíncrono, você está esperando a conclusão da tarefa assíncrona retornada por esse método. No seu caso, o método PegarTodosProfessoresAsync do repositório retorna uma tarefa Task<Professor[]>. O await no controlador aguarda a conclusão dessa tarefa antes de continuar a execução do código.
         * Portanto, o await no controlador é necessário para esperar que o método PegarTodosProfessoresAsync do repositório seja concluído antes de continuar a execução do código no controlador. Ele aguarda a conclusão da tarefa assíncrona retornada pelo método do repositório para garantir que você tenha os dados necessários antes de mapeá-los e retorná-los como uma resposta HTTP (usando Ok()).

         * Resumindo, embora o método PegarTodosProfessoresAsync do repositório já tenha um await, é necessário usar o await novamente no controlador para aguardar a conclusão da tarefa assíncrona retornada por esse método.
           Se você não utilizar o await no controlador ao chamar o método assíncrono PegarTodosProfessoresAsync do repositório, a chamada será feita de forma síncrona.

           Sem o await, o controlador não esperará a conclusão da tarefa assíncrona retornada pelo método do repositório. Em vez disso, ele continuará a executar o código subsequente imediatamente.

           Isso pode levar a problemas, pois o código subsequente no controlador provavelmente dependerá dos dados retornados pelo método assíncrono do repositório. Se você não esperar a conclusão da tarefa assíncrona, é possível que o controlador tente acessar ou manipular dados que ainda não foram totalmente recuperados, resultando em comportamento imprevisível ou erros.

           Portanto, é importante utilizar o await no controlador para aguardar a conclusão da tarefa assíncrona e garantir que você tenha os dados corretos antes de prosseguir com o restante do código. Isso garante a execução correta e sincronizada das operações assíncronas em seu aplicativo.   
         */



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

            _mapper.Map(CadProfessorDto, Professor);

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
