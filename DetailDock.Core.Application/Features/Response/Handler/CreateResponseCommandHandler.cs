using AutoMapper;
using DetailDock.Core.Application.Features.Response.Command;
using DetailDock.Core.Application.Features.Response.DTO;
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
    public class CreateResponseCommandHandler : IRequestHandler<CreateResponseCommand, IResponse>
    {
        private readonly IResponseRepository _responseRepository;
        private readonly IMapper _mapper;

        public CreateResponseCommandHandler(IResponseRepository responseRepository, IMapper mapper)
        {
            _responseRepository = responseRepository;
            _mapper = mapper;
        }

        public async Task<IResponse> Handle(CreateResponseCommand request, CancellationToken cancellationToken)
        {
            var responseDto = _mapper.Map<ResponseDTO>(request);
            var response = await _responseRepository.AddAsync(responseDto);
            return response;
        }
    }
}
