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
    public class GetBasicInfoByIdQueryHandler : IRequestHandler<GetBasicInfoByIdQuery, IResponse>
    {
        private readonly IBasicInfoRepository _BasicInfoRepository;

        public GetBasicInfoByIdQueryHandler(IBasicInfoRepository BasicInfoRepository)
        {
            _BasicInfoRepository = BasicInfoRepository;
        }

        public async Task<IResponse> Handle(GetBasicInfoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _BasicInfoRepository.GetBasicInfoByIdAsync(request.BasicInfoId);
        }
    }
}
