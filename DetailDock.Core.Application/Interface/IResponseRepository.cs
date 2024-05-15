using DetailDock.Core.Application.Features.Response.DTO;
using DetailDock.Core.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Interface
{
    public interface IResponseRepository
    {
        Task<IResponse> AddAsync(ResponseDTO responseDto);
        Task<IResponse> UpdateAsync(ResponseDTO responseDto);
        Task<IResponse> GetResponseByIdAsync(string responseId);
        Task<IResponse> GetAllResponsesAsync();
        Task<IResponse> DeleteAsync(string responseId);
    }
}
