using DetailDock.Core.Application.Features.Program.Query;
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
    public class GetProgramByIdQueryHandler : IRequestHandler<GetProgramByIdQuery, IResponse>
    {
        private readonly IProgramRepository _programRepository;

        public GetProgramByIdQueryHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task<IResponse> Handle(GetProgramByIdQuery request, CancellationToken cancellationToken)
        {
            return await _programRepository.GetByIdAsync(request.ProgramId);
        }
    }
}
