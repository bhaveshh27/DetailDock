using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Response
{
    public interface IResponse
    {
        HttpStatusCode StatusCode { get; }
        string Message { get; }
    }
}
