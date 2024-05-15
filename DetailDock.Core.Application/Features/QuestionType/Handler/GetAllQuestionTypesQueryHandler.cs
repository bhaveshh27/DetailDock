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
    public class GetAllQuestionTypesQueryHandler : IRequestHandler<GetAllQuestionTypesQuery, IResponse>
    {
        private readonly IQuestionTypeRepository _questionTypeRepository;

        public GetAllQuestionTypesQueryHandler(IQuestionTypeRepository questionTypeRepository)
        {
            _questionTypeRepository = questionTypeRepository;
        }

        public async Task<IResponse> Handle(GetAllQuestionTypesQuery request, CancellationToken cancellationToken)
        {
            return await _questionTypeRepository.GetAllQuestionTypesAsync();
        }
    }
}
