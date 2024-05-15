using DetailDock.Core.Application.Features.ResponseData.DTO;
using DetailDock.Core.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Features.Response.Command
{
    public class UpdateResponseCommand : IRequest<IResponse>
    {
        public string ResponseId { get; set; }
        public string QuestionId { get; set; }
        public ResponseDataDTO ResponseContent { get; set; }
    }
}
