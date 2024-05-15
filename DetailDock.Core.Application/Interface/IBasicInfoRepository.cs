using DetailDock.Core.Application.Features.BasicInfo.DTO;
using DetailDock.Core.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Interface
{
    public interface IBasicInfoRepository
    {
        Task<IResponse> AddAsync(BasicInfoDTO BasicInfo);
        Task<IResponse> UpdateAsync(BasicInfoDTO BasicInfo);
        Task<IResponse> GetBasicInfoByIdAsync(int BasicInfoId);
        Task<IResponse> GetAllBasicInfoAsync();
        Task<IResponse> DeleteAsync(int BasicInfoId);
    }
}
