using DetailDock.Core.Application.Features.QuestionType.Query;
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
    public class GetQuestionTypeByIdQueryHandler : IRequestHandler<GetQuestionTypeByIdQuery, IResponse>
    {
        private readonly IQuestionTypeRepository _questionTypeRepository;

        public GetQuestionTypeByIdQueryHandler(IQuestionTypeRepository questionTypeRepository)
        {
            _questionTypeRepository = questionTypeRepository;
        }

        public async Task<IResponse> Handle(GetQuestionTypeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _questionTypeRepository.GetQuestionTypeByIdAsync(request.QuestionTypeId);
        }
    }
}
