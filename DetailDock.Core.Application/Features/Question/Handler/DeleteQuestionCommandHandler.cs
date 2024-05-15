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
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, IResponse>
    {
        private readonly IQuestionRepository _QuestionRepository;

        public DeleteQuestionCommandHandler(IQuestionRepository QuestionRepository)
        {
            _QuestionRepository = QuestionRepository;
        }

        public async Task<IResponse> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            return await _QuestionRepository.DeleteAsync(request.QuestionId);
        }
    }
}
