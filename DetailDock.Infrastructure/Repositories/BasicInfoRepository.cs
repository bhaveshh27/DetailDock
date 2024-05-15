using AutoMapper;
using DetailDock.Core.Application.Features.BasicInfo.DTO;
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
    public class BasicInfoRepository : IBasicInfoRepository
    {
        private readonly Container _container;
        private readonly IMapper _mapper;

        public BasicInfoRepository(Container container, IMapper mapper)
        {
            _container = container;
            _mapper = mapper;
        }

        public async Task<IResponse> AddAsync(BasicInfoDTO BasicInfo)
        {
            try
            {
                var BasicInfoEntity = _mapper.Map<BasicInfo>(BasicInfo);
                CosmosClient client = new(
                  accountEndpoint: "https://localhost:8081",
                  authKeyOrResourceToken: "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw=="
                  );
                           Database database = await client.CreateDatabaseIfNotExistsAsync(
                             id: "FormData",
                               throughput: 400
                               );
                           Container container = await database.CreateContainerIfNotExistsAsync(
                               id: "BasicInfo",
                               partitionKeyPath: "/id"
                               );

                await _container.CreateItemAsync(BasicInfoEntity);
                return new DataResponse<BasicInfoDTO>(BasicInfo, HttpStatusCode.OK, "Personal Information added");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> UpdateAsync(BasicInfoDTO BasicInfo)
        {
            try
            {
                var BasicInfoEntity = _mapper.Map<BasicInfo>(BasicInfo);
                await _container.UpsertItemAsync(BasicInfoEntity);
                return new DataResponse<BasicInfoDTO>(BasicInfo, HttpStatusCode.OK, "Personal Information Update Successful");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> GetBasicInfoByIdAsync(int BasicInfoId)
        {
            try
            {
                var BasicInfo = await _container.ReadItemAsync<BasicInfo>(BasicInfoId.ToString(), new PartitionKey(BasicInfoId.ToString()));
                return new DataResponse<BasicInfoDTO>(_mapper.Map<BasicInfoDTO>(BasicInfo.Resource), HttpStatusCode.OK, "Personal Information by id");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> GetAllBasicInfoAsync()
        {
            try
            {
                var queryIterator = _container.GetItemQueryIterator<BasicInfo>();
                var BasicInfos = new List<BasicInfo>();

                while (queryIterator.HasMoreResults)
                {
                    var response = await queryIterator.ReadNextAsync();
                    BasicInfos.AddRange(response);
                }
                var BasicInfoDTOs = _mapper.Map<IEnumerable<BasicInfoDTO>>(BasicInfos);

                return new DataResponse<IEnumerable<BasicInfoDTO>>(BasicInfoDTOs, HttpStatusCode.OK, "All personal information");
            }
            catch (Exception ex)
            {

                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        public async Task<IResponse> DeleteAsync(int BasicInfoId)
        {
            try
            {
                var response = await _container.DeleteItemAsync<BasicInfo>(BasicInfoId.ToString(), new PartitionKey(BasicInfoId.ToString()));
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return new DataResponse<object>(null, HttpStatusCode.OK, "Personal Information Delete Successful");
                }
                return new DataResponse<object>(null, HttpStatusCode.BadRequest, "Personal Information Not Found");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }

}
