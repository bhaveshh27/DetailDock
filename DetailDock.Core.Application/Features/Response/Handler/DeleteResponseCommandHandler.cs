using DetailDock.Core.Application.Features.Response.Command;
using DetailDock.Core.Application.Interface;
using DetailDock.Core.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Features.Response.Handler
{
    public class DeleteResponseCommandHandler : IRequestHandler<DeleteResponseCommand, IResponse>
    {
        private readonly IResponseRepository _responseRepository;

        public DeleteResponseCommandHandler(IResponseRepository responseRepository)
        {
            _responseRepository = responseRepository;
        }

        public async Task<IResponse> Handle(DeleteResponseCommand request, CancellationToken cancellationToken)
        {
            return await _responseRepository.DeleteAsync(request.ResponseId);
        }
    }
}
