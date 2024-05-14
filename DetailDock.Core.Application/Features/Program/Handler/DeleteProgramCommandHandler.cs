using DetailDock.Core.Application.Features.Program.Command;
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
    public class DeleteProgramCommandHandler : IRequestHandler<DeleteProgramCommand, IResponse>
    {
        private readonly IProgramRepository _programRepository;

        public DeleteProgramCommandHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task<IResponse> Handle(DeleteProgramCommand request, CancellationToken cancellationToken)
        {
            return await _programRepository.DeleteAsync(request.ProgramId);
        }
    }
}
