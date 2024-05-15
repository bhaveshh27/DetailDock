using DetailDock.Core.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Features.ResponseData.Command
{
    public class UpdateResponseDataCommand : IRequest<IResponse>
    {
        public string ResponseDataId { get; set; }
        public string Text { get; set; }
        public double? Numeric { get; set; }
        public DateTime? Date { get; set; }
    }
}
