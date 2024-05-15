using AutoMapper;
using DetailDock.Core.Application.Features.BasicInfo.Command;
using DetailDock.Core.Application.Features.BasicInfo.DTO;
using DetailDock.Core.Application.Features.Program.Command;
using DetailDock.Core.Application.Features.Program.DTO;
using DetailDock.Core.Application.Features.QuestionType.Command;
using DetailDock.Core.Application.Features.QuestionType.DTO;
using DetailDock.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Mappings
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {

            CreateMap<CreateProgramCommand, ProgramDTO>().ReverseMap();
            CreateMap<UpdateProgramCommand, ProgramDTO>().ReverseMap();
            CreateMap<ProgramDTO, Program>().ReverseMap();
            CreateMap<CreateQuestionTypeCommand, QuestionType>().ReverseMap();
            CreateMap<UpdateQuestionTypeCommand, QuestionType>().ReverseMap();
            CreateMap<QuestionTypeDTO, QuestionType>().ReverseMap();
            CreateMap<CreateBasicInfoCommand, BasicInfoDTO>().ReverseMap();
            CreateMap<UpdateBasicInfoCommand, BasicInfoDTO>().ReverseMap();
            CreateMap<BasicInfoDTO, BasicInfo>().ReverseMap();
        }

    }
}
