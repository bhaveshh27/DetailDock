using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Response
{
    public class DataResponse<T> : IDataResponse<T>
    {
        public T? Data { get; }

        public HttpStatusCode StatusCode { get; }
        public string? Message { get; }

        [JsonConstructor]
        public DataResponse(T? data, HttpStatusCode statuscode, string? errors)
        {
            Data = data;
            StatusCode = statuscode;
            Message = errors;
        }
    }
}
