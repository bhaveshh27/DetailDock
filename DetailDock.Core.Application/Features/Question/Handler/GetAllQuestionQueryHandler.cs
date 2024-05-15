using DetailDock.Core.Application.Features.Question.Query;
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
    public class GetAllQuestionsQueryHandler : IRequestHandler<GetAllQuestionsQuery, IResponse>
    {
        private readonly IQuestionRepository _QuestionRepository;

        public GetAllQuestionsQueryHandler(IQuestionRepository QuestionRepository)
        {
            _QuestionRepository = QuestionRepository;
        }

        public async Task<IResponse> Handle(GetAllQuestionsQuery request, CancellationToken cancellationToken)
        {
            return await _QuestionRepository.GetAllQuestionsAsync();
        }
    }
}
