using DetailDock.Core.Application.Response;
using DetailDock.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Interface
{
    public interface IQuestionTypeRepository
    {
        Task<IResponse> AddAsync(QuestionType questionType);
        Task<IResponse> UpdateAsync(QuestionType questionType);
        Task<IResponse> GetQuestionTypeByIdAsync(string questionTypeId);
        Task<IResponse> GetAllQuestionTypesAsync();
        Task<IResponse> DeleteAsync(string questionTypeId);
        Task SaveChangesAsync();
    }
}
