using AutoMapper;
using DetailDock.Core.Application.Features.Program.Command;
using DetailDock.Core.Application.Features.Program.DTO;
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
           
        }

    }
}
