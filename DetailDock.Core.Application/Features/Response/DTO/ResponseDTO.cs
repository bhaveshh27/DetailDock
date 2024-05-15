using DetailDock.Core.Application.Features.ResponseData.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Features.Response.DTO
{
    public class ResponseDTO
    {
        public string QuestionId { get; set; }
        public ResponseDataDTO ResponseContent { get; set; }
    }
}
