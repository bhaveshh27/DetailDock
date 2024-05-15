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
    public class DeleteQuestionTypeCommandHandler : IRequestHandler<DeleteQuestionTypeCommand, IResponse>
    {
        private readonly IQuestionTypeRepository _questionTypeRepository;

        public DeleteQuestionTypeCommandHandler(IQuestionTypeRepository questionTypeRepository)
        {
            _questionTypeRepository = questionTypeRepository;
        }

        public async Task<IResponse> Handle(DeleteQuestionTypeCommand request, CancellationToken cancellationToken)
        {
            return await _questionTypeRepository.DeleteAsync(request.QuestionTypeId);
        }
    }
}
