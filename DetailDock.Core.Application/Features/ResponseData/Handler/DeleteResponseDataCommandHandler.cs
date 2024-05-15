using DetailDock.Core.Application.Features.ResponseData.Command;
using DetailDock.Core.Application.Interface;
using DetailDock.Core.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Features.ResponseData.Handler
{
    public class DeleteResponseDataCommandHandler : IRequestHandler<DeleteResponseDataCommand, IResponse>
    {
        private readonly IResponseDataRepository _responseDataRepository;

        public DeleteResponseDataCommandHandler(IResponseDataRepository responseDataRepository)
        {
            _responseDataRepository = responseDataRepository;
        }

        public async Task<IResponse> Handle(DeleteResponseDataCommand request, CancellationToken cancellationToken)
        {
            return await _responseDataRepository.DeleteAsync(request.ResponseDataId);
        }
    }
}
