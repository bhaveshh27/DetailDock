using AutoMapper;
using DetailDock.Core.Application.Features.Program.Command;
using DetailDock.Core.Application.Features.Program.DTO;
using DetailDock.Core.Application.Interface;
using DetailDock.Core.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Features.Program.Handler
{
    public class UpdateProgramCommandHandler : IRequestHandler<UpdateProgramCommand, IResponse>
    {
        private readonly IProgramRepository _programRepository;
        private readonly IMapper _mapper;

        public UpdateProgramCommandHandler(IProgramRepository programRepository, IMapper mapper)
        {
            _programRepository = programRepository;
            _mapper = mapper;
        }

        public async Task<IResponse> Handle(UpdateProgramCommand request, CancellationToken cancellationToken)
        {
            var programDto = _mapper.Map<ProgramDTO>(request);
            var response = await _programRepository.UpdateAsync(programDto);
            return response;
        }
    }
}
