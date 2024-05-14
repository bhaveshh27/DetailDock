using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Response
{
    public interface IDataResponse<T> : IResponse
    {
        T Data { get; }
    }
}
