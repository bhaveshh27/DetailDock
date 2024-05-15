using AutoMapper;
using DetailDock.Core.Application.Features.ResponseData.DTO;
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
    public class ResponseDataRepository : IResponseDataRepository
    {
        private readonly Container _container;
        private readonly IMapper _mapper;

        public ResponseDataRepository(Container container, IMapper mapper)
        {
            _container = container;
            _mapper = mapper;
        }

        public async Task<IResponse> AddAsync(ResponseDataDTO responseTypeDto)
        {
            try
            {
                var responseTypeEntity = _mapper.Map<ResponseData>(responseTypeDto);
                await _container.CreateItemAsync(responseTypeEntity);
                return new DataResponse<ResponseDataDTO>(responseTypeDto, HttpStatusCode.OK, "ResponseData added");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> UpdateAsync(ResponseDataDTO responseTypeDto)
        {
            try
            {
                var responseTypeEntity = _mapper.Map<ResponseData>(responseTypeDto);
                await _container.UpsertItemAsync(responseTypeEntity);
                return new DataResponse<ResponseDataDTO>(responseTypeDto, HttpStatusCode.OK, "ResponseData update successful");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> GetResponseDataByIdAsync(string responseTypeId)
        {
            try
            {
                var responseType = await _container.ReadItemAsync<ResponseData>(responseTypeId, new PartitionKey(responseTypeId));
                return new DataResponse<ResponseDataDTO>(_mapper.Map<ResponseDataDTO>(responseType.Resource), HttpStatusCode.OK, "ResponseData by id");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> GetAllResponseDataAsync()
        {
            try
            {
                var queryIterator = _container.GetItemQueryIterator<ResponseData>();
                var responseTypes = new List<ResponseData>();

                while (queryIterator.HasMoreResults)
                {
                    var response = await queryIterator.ReadNextAsync();
                    responseTypes.AddRange(response);
                }

                var responseTypeDtos = _mapper.Map<IEnumerable<ResponseDataDTO>>(responseTypes);
                return new DataResponse<IEnumerable<ResponseDataDTO>>(responseTypeDtos, HttpStatusCode.OK, "All response types");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> DeleteAsync(string responseTypeId)
        {
            try
            {
                var response = await _container.DeleteItemAsync<ResponseData>(responseTypeId, new PartitionKey(responseTypeId));
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return new DataResponse<object>(null, HttpStatusCode.OK, "ResponseData deleted successfully");
                }
                return new DataResponse<object>(null, HttpStatusCode.BadRequest, "ResponseData not found");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }


    }

}
