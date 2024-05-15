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
    public class GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQuery, IResponse>
    {
        private readonly IQuestionRepository _QuestionRepository;

        public GetQuestionByIdQueryHandler(IQuestionRepository QuestionRepository)
        {
            _QuestionRepository = QuestionRepository;
        }

        public async Task<IResponse> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _QuestionRepository.GetQuestionByIdAsync(request.QuestionId);
        }
    }
}
