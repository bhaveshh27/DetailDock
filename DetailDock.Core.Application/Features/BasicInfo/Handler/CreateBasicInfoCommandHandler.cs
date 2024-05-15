using AutoMapper;
using DetailDock.Core.Application.Features.BasicInfo.Command;
using DetailDock.Core.Application.Features.BasicInfo.DTO;
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
    public class CreateBasicInfoCommandHandler : IRequestHandler<CreateBasicInfoCommand, IResponse>
    {
        private readonly IBasicInfoRepository _BasicInfoRepository;
        private readonly IMapper _mapper;

        public CreateBasicInfoCommandHandler(IBasicInfoRepository BasicInfoRepository, IMapper mapper)
        {
            _BasicInfoRepository = BasicInfoRepository;
            _mapper = mapper;
        }

        public async Task<IResponse> Handle(CreateBasicInfoCommand request, CancellationToken cancellationToken)
        {
            var BasicInfoDto = _mapper.Map<BasicInfoDTO>(request);
            var response = await _BasicInfoRepository.AddAsync(BasicInfoDto);
            return response;
        }
    }
}
