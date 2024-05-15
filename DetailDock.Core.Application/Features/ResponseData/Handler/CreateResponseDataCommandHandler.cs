using AutoMapper;
using DetailDock.Core.Application.Features.ResponseData.Command;
using DetailDock.Core.Application.Features.ResponseData.DTO;
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
    public class CreateResponseDataCommandHandler : IRequestHandler<CreateResponseDataCommand, IResponse>
    {
        private readonly IResponseDataRepository _responseDataRepository;
        private readonly IMapper _mapper;

        public CreateResponseDataCommandHandler(IResponseDataRepository responseDataRepository, IMapper mapper)
        {
            _responseDataRepository = responseDataRepository;
            _mapper = mapper;
        }

        public async Task<IResponse> Handle(CreateResponseDataCommand request, CancellationToken cancellationToken)
        {
            var responseDataDto = _mapper.Map<ResponseDataDTO>(request);
            var response = await _responseDataRepository.AddAsync(responseDataDto);
            return response;
        }
    }
}
