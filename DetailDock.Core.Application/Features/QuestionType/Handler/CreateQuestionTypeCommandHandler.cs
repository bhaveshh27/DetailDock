using AutoMapper;
using DetailDock.Core.Application.Features.QuestionType.Command;
using DetailDock.Core.Application.Interface;
using DetailDock.Core.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Features.QuestionType.Handler
{
    public class CreateQuestionTypeCommandHandler : IRequestHandler<CreateQuestionTypeCommand, IResponse>
    {
        private readonly IQuestionTypeRepository _questionTypeRepository;
        private readonly IMapper _mapper;

        public CreateQuestionTypeCommandHandler(IQuestionTypeRepository questionTypeRepository, IMapper mapper)
        {
            _questionTypeRepository = questionTypeRepository;
            _mapper = mapper;
        }

        public async Task<IResponse> Handle(CreateQuestionTypeCommand request, CancellationToken cancellationToken)
        {
            var questionType = _mapper.Map<Domain.Entities.QuestionType>(request);
            var response = await _questionTypeRepository.AddAsync(questionType);
            return response;
        }
    }

}
