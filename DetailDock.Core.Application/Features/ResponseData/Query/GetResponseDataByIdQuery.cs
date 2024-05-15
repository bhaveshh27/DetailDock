using DetailDock.Core.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Features.ResponseData.Query
{
    public class GetResponseDataByIdQuery : IRequest<IResponse>
    {
        public string ResponseDataId { get; set; }
    }
}
