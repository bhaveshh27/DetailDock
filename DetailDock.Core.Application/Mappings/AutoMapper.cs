using AutoMapper;
using DetailDock.Core.Application.Features.BasicInfo.Command;
using DetailDock.Core.Application.Features.BasicInfo.DTO;
using DetailDock.Core.Application.Features.Program.Command;
using DetailDock.Core.Application.Features.Program.DTO;
using DetailDock.Core.Application.Features.Question.Command;
using DetailDock.Core.Application.Features.Question.DTO;
using DetailDock.Core.Application.Features.Response.Command;
using DetailDock.Core.Application.Features.Response.DTO;
using DetailDock.Core.Application.Features.ResponseData.Command;
using DetailDock.Core.Application.Features.ResponseData.DTO;
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
            CreateMap<CreateQuestionCommand, Question>().ReverseMap();
            CreateMap<UpdateQuestionCommand, Question>().ReverseMap();
            CreateMap<QuestionDTO, Question>().ReverseMap();
            CreateMap<CreateBasicInfoCommand, BasicInfoDTO>().ReverseMap();
            CreateMap<UpdateBasicInfoCommand, BasicInfoDTO>().ReverseMap();
            CreateMap<BasicInfoDTO, BasicInfo>().ReverseMap();
            CreateMap<CreateResponseCommand, ResponseDTO>().ReverseMap();
            CreateMap<UpdateResponseCommand, ResponseDTO>().ReverseMap();
            CreateMap<ResponseDTO, DetailDock.Core.Domain.Entities.Response>().ReverseMap();
            CreateMap<CreateResponseDataCommand, ResponseDataDTO>().ReverseMap();
            CreateMap<UpdateResponseDataCommand, ResponseDataDTO>().ReverseMap();
            CreateMap<ResponseDataDTO, ResponseData>().ReverseMap();
        }

    }
}
