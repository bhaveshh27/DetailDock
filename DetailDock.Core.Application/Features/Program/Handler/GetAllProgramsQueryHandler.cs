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
    public class GetAllProgramsQueryHandler : IRequestHandler<GetAllProgramQuery, IResponse>
    {
        private readonly IProgramRepository _programRepository;

        public GetAllProgramsQueryHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task<IResponse> Handle(GetAllProgramQuery request, CancellationToken cancellationToken)
        {
            return await _programRepository.GetAllAsync();
        }
    }
}
