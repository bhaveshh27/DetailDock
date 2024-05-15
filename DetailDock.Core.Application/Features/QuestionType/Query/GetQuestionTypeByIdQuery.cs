using DetailDock.Core.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Features.QuestionType.Query
{
    public class GetQuestionTypeByIdQuery : IRequest<IResponse>
    {
        public string QuestionTypeId { get; set; }
    }

}
