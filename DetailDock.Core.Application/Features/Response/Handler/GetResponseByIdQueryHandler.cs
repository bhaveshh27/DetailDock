using DetailDock.Core.Application.Features.Response.Query;
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
    public class GetResponseByIdQueryHandler : IRequestHandler<GetResponseByIdQuery, IResponse>
    {
        private readonly IResponseRepository _responseRepository;

        public GetResponseByIdQueryHandler(IResponseRepository responseRepository)
        {
            _responseRepository = responseRepository;
        }

        public async Task<IResponse> Handle(GetResponseByIdQuery request, CancellationToken cancellationToken)
        {
            return await _responseRepository.GetResponseByIdAsync(request.ResponseId);
        }
    }
}
