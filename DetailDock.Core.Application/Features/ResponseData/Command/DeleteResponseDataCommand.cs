using DetailDock.Core.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Features.ResponseData.Command
{
    public class DeleteResponseDataCommand : IRequest<IResponse>
    {
        public string ResponseDataId { get; set; }
    }
}
