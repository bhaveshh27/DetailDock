using DetailDock.Core.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Features.Response.Query
{
    public class GetResponseByIdQuery : IRequest<IResponse>
    {
        public string ResponseId { get; set; }
    }
}
