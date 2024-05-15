using DetailDock.Core.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Features.Question.Command
{
    public class DeleteQuestionCommand : IRequest<IResponse>
    {
        public string QuestionId { get; set; }
    }
}
