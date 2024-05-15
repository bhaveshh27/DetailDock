using DetailDock.Core.Application.Features.BasicInfo.Query;
using DetailDock.Core.Application.Interface;
using DetailDock.Core.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Features.BasicInfo.Handler
{
    public class GetAllBasicInfoQueryHandler : IRequestHandler<GetAllBasicInfoQuery, IResponse>
    {
        private readonly IBasicInfoRepository _BasicInfoRepository;

        public GetAllBasicInfoQueryHandler(IBasicInfoRepository BasicInfoRepository)
        {
            _BasicInfoRepository = BasicInfoRepository;
        }

        public async Task<IResponse> Handle(GetAllBasicInfoQuery request, CancellationToken cancellationToken)
        {
            return await _BasicInfoRepository.GetAllBasicInfoAsync();
        }
    }
}
