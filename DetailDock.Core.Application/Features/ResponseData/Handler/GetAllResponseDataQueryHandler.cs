using DetailDock.Core.Application.Features.ResponseData.Query;
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
    public class GetAllResponseDataQueryHandler : IRequestHandler<GetAllResponseDataQuery, IResponse>
    {
        private readonly IResponseDataRepository _responseDataRepository;

        public GetAllResponseDataQueryHandler(IResponseDataRepository responseDataRepository)
        {
            _responseDataRepository = responseDataRepository;
        }

        public async Task<IResponse> Handle(GetAllResponseDataQuery request, CancellationToken cancellationToken)
        {
            return await _responseDataRepository.GetAllResponseDataAsync();
        }
    }
}
