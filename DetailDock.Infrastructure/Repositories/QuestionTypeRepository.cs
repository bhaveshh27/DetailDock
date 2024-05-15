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
    public class QuestionTypeRepository : IQuestionTypeRepository
    {
        private readonly Container _container;
        private readonly IMapper _mapper;

        public QuestionTypeRepository(Container container, IMapper mapper)
        {
            _container = container;
            _mapper = mapper;
        }

        public async Task<IResponse> AddAsync(QuestionType questionType)
        {
            try
            {
                var questionTypeEntity = _mapper.Map<QuestionType>(questionType);
                await _container.CreateItemAsync(questionTypeEntity);
                return new DataResponse<QuestionType>(questionType, HttpStatusCode.OK, "QuestionType added");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> UpdateAsync(QuestionType questionType)
        {
            try
            {
                var questionTypeEntity = _mapper.Map<QuestionType>(questionType);
                await _container.UpsertItemAsync(questionTypeEntity);
                return new DataResponse<QuestionType>(questionType, HttpStatusCode.OK, "QuestionType Update Successful");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> GetQuestionTypeByIdAsync(string questionTypeId)
        {
            try
            {
                var questionType = await _container.ReadItemAsync<QuestionType>(questionTypeId, new PartitionKey(questionTypeId));
                return new DataResponse<QuestionType>(questionType.Resource, HttpStatusCode.OK, "QuestionType by id");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> GetAllQuestionTypesAsync()
        {
            try
            {
                var queryIterator = _container.GetItemQueryIterator<QuestionType>();
                var questionTypes = new List<QuestionType>();

                while (queryIterator.HasMoreResults)
                {
                    var response = await queryIterator.ReadNextAsync();
                    questionTypes.AddRange(response);
                }
                return new DataResponse<IEnumerable<QuestionType>>(questionTypes, HttpStatusCode.OK, "All question types");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> DeleteAsync(string questionTypeId)
        {
            try
            {
                var response = await _container.DeleteItemAsync<QuestionType>(questionTypeId, new PartitionKey(questionTypeId));
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return new DataResponse<object>(null, HttpStatusCode.OK, "QuestionType Delete Successful");
                }
                return new DataResponse<object>(null, HttpStatusCode.BadRequest, "QuestionType Not Found");
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
