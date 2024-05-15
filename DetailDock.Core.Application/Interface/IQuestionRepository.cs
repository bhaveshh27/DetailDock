using DetailDock.Core.Application.Response;
using DetailDock.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Core.Application.Interface
{
    public interface IQuestionRepository
    {
        Task<IResponse> AddAsync(Question Question);
        Task<IResponse> UpdateAsync(Question Question);
        Task<IResponse> GetQuestionByIdAsync(string QuestionId);
        Task<IResponse> GetAllQuestionsAsync();
        Task<IResponse> DeleteAsync(string QuestionId);
        Task SaveChangesAsync();
    }
}
