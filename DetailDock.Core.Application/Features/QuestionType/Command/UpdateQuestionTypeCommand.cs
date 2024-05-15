using DetailDock.Core.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Features.QuestionType.Command
{
    public class UpdateQuestionTypeCommand : IRequest<IResponse>
    {
        public string Id { get; set; }
        public string ParagraphQuestion { get; set; }
        public bool YesNo { get; set; }
        public string DropDown { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
    }
}
