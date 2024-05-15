using DetailDock.Core.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Features.BasicInfo.Query
{
    public class GetBasicInfoByIdQuery : IRequest<IResponse>
    {
        public int BasicInfoId { get; set; }
    }
}
