using AutoMapper;
using DetailDock.Core.Application.Features.Response.DTO;
using DetailDock.Core.Application.Interface;
using DetailDock.Core.Application.Response;
using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DetailDock.Infrastructure.Repositories
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly Container _container;
        private readonly IMapper _mapper;

        public ResponseRepository(Container container, IMapper mapper)
        {
            _container = container;
            _mapper = mapper;
        }

        public async Task<IResponse> AddAsync(ResponseDTO responseDto)
        {
            try
            {
                var responseEntity = _mapper.Map<DetailDock.Core.Domain.Entities.Response>(responseDto);
                await _container.CreateItemAsync(responseEntity);
                return new DataResponse<ResponseDTO>(responseDto, HttpStatusCode.OK, "Response added");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> UpdateAsync(ResponseDTO responseDto)
        {
            try
            {
                var responseEntity = _mapper.Map<DetailDock.Core.Domain.Entities.Response>(responseDto);
                await _container.UpsertItemAsync(responseEntity);
                return new DataResponse<ResponseDTO>(responseDto, HttpStatusCode.OK, "Response update successful");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> GetResponseByIdAsync(string responseId)
        {
            try
            {
                var response = await _container.ReadItemAsync<DetailDock.Core.Domain.Entities.Response>(responseId, new PartitionKey(responseId));
                return new DataResponse<ResponseDTO>(_mapper.Map<ResponseDTO>(response.Resource), HttpStatusCode.OK, "Response by id");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> GetAllResponsesAsync()
        {
            try
            {
                var queryIterator = _container.GetItemQueryIterator<DetailDock.Core.Domain.Entities.Response>();
                var responses = new List<DetailDock.Core.Domain.Entities.Response>();

                while (queryIterator.HasMoreResults)
                {
                    var response = await queryIterator.ReadNextAsync();
                    responses.AddRange(response);
                }

                var responseDtos = _mapper.Map<IEnumerable<ResponseDTO>>(responses);
                return new DataResponse<IEnumerable<ResponseDTO>>(responseDtos, HttpStatusCode.OK, "All responses");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> DeleteAsync(string responseId)
        {
            try
            {
                var response = await _container.DeleteItemAsync<DetailDock.Core.Domain.Entities.Response>(responseId, new PartitionKey(responseId));
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return new DataResponse<object>(null, HttpStatusCode.OK, "Response deleted successfully");
                }
                return new DataResponse<object>(null, HttpStatusCode.BadRequest, "Response not found");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

       
    }

}
