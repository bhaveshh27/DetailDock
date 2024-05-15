using DetailDock.Core.Application.Features.BasicInfo.Command;
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
    public class DeleteBasicInfoCommandHandler : IRequestHandler<DeleteBasicInfoCommand, IResponse>
    {
        private readonly IBasicInfoRepository _BasicInfoRepository;

        public DeleteBasicInfoCommandHandler(IBasicInfoRepository BasicInfoRepository)
        {
            _BasicInfoRepository = BasicInfoRepository;
        }

        public async Task<IResponse> Handle(DeleteBasicInfoCommand request, CancellationToken cancellationToken)
        {
            return await _BasicInfoRepository.DeleteAsync(request.BasicInfoId);
        }
    }
}
