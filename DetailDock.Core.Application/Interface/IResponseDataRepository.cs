using DetailDock.Core.Application.Features.ResponseData.DTO;
using DetailDock.Core.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Interface
{
    public interface IResponseDataRepository
    {
        Task<IResponse> AddAsync(ResponseDataDTO responseDataDto);
        Task<IResponse> UpdateAsync(ResponseDataDTO responseDataDto);
        Task<IResponse> GetResponseDataByIdAsync(string responseDataId);
        Task<IResponse> GetAllResponseDataAsync();
        Task<IResponse> DeleteAsync(string responseDataId);
        
    }
}
