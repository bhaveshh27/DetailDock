using AutoMapper;
using DetailDock.Core.Application.Features.Program.DTO;
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
    public class ProgramRepository : IProgramRepository
    {
        private readonly Container _container;
        private readonly IMapper _mapper;

        public ProgramRepository(Container container, IMapper mapper)
        {
            _container = container;
            _mapper = mapper;
        }

        public async Task<IResponse> AddAsync(ProgramDTO program)
        {
            try
            {
                var programEntity = _mapper.Map<Program>(program);
                var add = await _container.CreateItemAsync(programEntity, new PartitionKey(programEntity.Id.ToString()));
                return new DataResponse<ProgramDTO>(program, HttpStatusCode.OK, "Program added");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> UpdateAsync(ProgramDTO program)
        {
            try
            {
                var programEntity = _mapper.Map<Program>(program);
                await _container.UpsertItemAsync(programEntity);
                return new DataResponse<ProgramDTO>(program, HttpStatusCode.OK, "Program update successful");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> GetByIdAsync(int programId)
        {
            try
            {
                var program = await _container.ReadItemAsync<Program>(programId.ToString(), new PartitionKey(programId.ToString()));
                return new DataResponse<ProgramDTO>(_mapper.Map<ProgramDTO>(program.Resource), HttpStatusCode.OK, "Program retrieved by ID");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> GetAllAsync()
        {
            try
            {
                var queryIterator = _container.GetItemQueryIterator<Program>();
                var programs = new List<Program>();

                while (queryIterator.HasMoreResults)
                {
                    var response = await queryIterator.ReadNextAsync();
                    programs.AddRange(response);
                }

                var programDTOs = _mapper.Map<IEnumerable<ProgramDTO>>(programs);

                return new DataResponse<IEnumerable<ProgramDTO>>(programDTOs, HttpStatusCode.OK, "All programs retrieved");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IResponse> DeleteAsync(int programId)
        {
            try
            {
                var response = await _container.DeleteItemAsync<Program>(programId.ToString(), new PartitionKey(programId.ToString()));
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return new DataResponse<object>(null, HttpStatusCode.OK, "Program deleted successfully");
                }
                return new DataResponse<object>(null, HttpStatusCode.BadRequest, "Program not found");
            }
            catch (Exception ex)
            {
                return new DataResponse<string>("", HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        
    }
}
