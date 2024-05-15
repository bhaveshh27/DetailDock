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
    public class GetResponseDataByIdQueryHandler : IRequestHandler<GetResponseDataByIdQuery, IResponse>
    {
        private readonly IResponseDataRepository _responseDataRepository;

        public GetResponseDataByIdQueryHandler(IResponseDataRepository responseDataRepository)
        {
            _responseDataRepository = responseDataRepository;
        }

        public async Task<IResponse> Handle(GetResponseDataByIdQuery request, CancellationToken cancellationToken)
        {
            return await _responseDataRepository.GetResponseDataByIdAsync(request.ResponseDataId);
        }
    }
}
