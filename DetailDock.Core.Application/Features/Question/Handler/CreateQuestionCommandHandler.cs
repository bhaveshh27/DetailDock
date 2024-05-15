using AutoMapper;
using DetailDock.Core.Application.Features.Question.Command;
using DetailDock.Core.Application.Interface;
using DetailDock.Core.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Features.Question.Handler
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, IResponse>
    {
        private readonly IQuestionRepository _QuestionRepository;
        private readonly IMapper _mapper;

        public CreateQuestionCommandHandler(IQuestionRepository QuestionRepository, IMapper mapper)
        {
            _QuestionRepository = QuestionRepository;
            _mapper = mapper;
        }

        public async Task<IResponse> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var Question = _mapper.Map<Domain.Entities.Question>(request);
            var response = await _QuestionRepository.AddAsync(Question);
            return response;
        }
    }

}
