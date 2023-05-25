using AngularSchool.API.Dtos;
using AngularSchool.API.Models;
using AngularSchool.API.Extensions;
using AutoMapper;

namespace AngularSchool.API.Helpers
{
    public class AngularSchoolProfile:Profile
    {
        public AngularSchoolProfile()
        {
            #region MapAluno
            CreateMap<Aluno, AlunoDto>().ForMember(Dto => Dto.Nome, Configuracao => Configuracao.MapFrom(Aluno => $"{Aluno.Nome} {Aluno.Sobrenome}"))
            .ForMember(Dto => Dto.Idade, Configuracao => Configuracao.MapFrom(AlunoIdade => AlunoIdade.DataNascimento.PegarIdadeAtual()));

            CreateMap<AlunoDto, Aluno>();
            CreateMap<Aluno, CadastraAlunoDto>().ReverseMap(); // Converte tanto de aluno para CastraAlunoDto quanto o caminho contrário
            #endregion

            #region MapProfessor
            CreateMap<Professor, ProfessorDto>().ForMember(ProfDto => ProfDto.Nome, Configuracao => Configuracao.MapFrom(Professor => $"{Professor.Nome} {Professor.Sobrenome}"));
            CreateMap<Professor, CadastraProfessorDto>().ReverseMap();



            #endregion
        }
    }
}
