using AutoMapper;
using DetailDock.Core.Application.Interface;
using DetailDock.Core.Application.Response;
using DetailDock.Core.Domain.Entities;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Infrastructure.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly Container _container;
        private readonly IMapper _mapper;

        public QuestionRepository(Container container, IMapper mapper)
        {
            _container = container;
            _mapper = mapper;
        }

        public async Task<IResponse> AddAsync(Question Question)
        {
            try
            {
                var QuestionEntity = _mapper.Map<Question>(Question);
                await _container.CreateItemAsync(QuestionEntity);
                return new DataResponse<Question>(Question, HttpStatusCode.OK, "Question added");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> UpdateAsync(Question Question)
        {
            try
            {
                var QuestionEntity = _mapper.Map<Question>(Question);
                await _container.UpsertItemAsync(QuestionEntity);
                return new DataResponse<Question>(Question, HttpStatusCode.OK, "Question Update Successful");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> GetQuestionByIdAsync(string QuestionId)
        {
            try
            {
                var Question = await _container.ReadItemAsync<Question>(QuestionId, new PartitionKey(QuestionId));
                return new DataResponse<Question>(Question.Resource, HttpStatusCode.OK, "Question by id");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> GetAllQuestionsAsync()
        {
            try
            {
                var queryIterator = _container.GetItemQueryIterator<Question>();
                var Questions = new List<Question>();

                while (queryIterator.HasMoreResults)
                {
                    var response = await queryIterator.ReadNextAsync();
                    Questions.AddRange(response);
                }
                return new DataResponse<IEnumerable<Question>>(Questions, HttpStatusCode.OK, "All question types");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> DeleteAsync(string QuestionId)
        {
            try
            {
                var response = await _container.DeleteItemAsync<Question>(QuestionId, new PartitionKey(QuestionId));
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return new DataResponse<object>(null, HttpStatusCode.OK, "Question Delete Successful");
                }
                return new DataResponse<object>(null, HttpStatusCode.BadRequest, "Question Not Found");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task SaveChangesAsync()
        {
            // Azure Cosmos DB automatically saves changes upon item creation or modification, so no explicit action needed here.
            await Task.CompletedTask;
        }
    }

}
