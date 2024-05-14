using DetailDock.Core.Application.Features.Program.DTO;
using DetailDock.Core.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Interface
{
    public interface IProgramRepository
    {
        Task<IResponse> AddAsync(ProgramDTO program);
        Task<IResponse> UpdateAsync(ProgramDTO program);
        Task<IResponse> GetByIdAsync(int programId);
        Task<IResponse> GetAllAsync();
        Task<IResponse> DeleteAsync(int programId);
    }
}
