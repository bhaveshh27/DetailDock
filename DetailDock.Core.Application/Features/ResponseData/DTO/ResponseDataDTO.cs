using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Features.ResponseData.DTO
{
    public class ResponseDataDTO
    {
        public string Text { get; set; }
        public double? Numeric { get; set; }
        public DateTime? Date { get; set; }
    }
}
