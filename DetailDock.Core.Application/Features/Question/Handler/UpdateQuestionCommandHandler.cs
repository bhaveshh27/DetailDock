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
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, IResponse>
    {
        private readonly IQuestionRepository _QuestionRepository;
        private readonly IMapper _mapper;

        public UpdateQuestionCommandHandler(IQuestionRepository QuestionRepository, IMapper mapper)
        {
            _QuestionRepository = QuestionRepository;
            _mapper = mapper;
        }

        public async Task<IResponse> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var Question = _mapper.Map<Domain.Entities.Question>(request);
            var response = await _QuestionRepository.UpdateAsync(Question);
            return response;
        }
    }

}
