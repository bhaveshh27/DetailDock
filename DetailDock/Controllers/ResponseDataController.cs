using DetailDock.Core.Application.Features.ResponseData.Command;
using DetailDock.Core.Application.Features.ResponseData.DTO;
using DetailDock.Core.Application.Features.ResponseData.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DetailDock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResponseDataController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResponseDataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ResponseDataDTO>>> GetAllResponseDatas()
        {
            var query = new GetAllResponseDataQuery();
            var responseTypes = await _mediator.Send(query);
            return Ok(responseTypes);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<ResponseDataDTO>> GetResponseDataById(string id)
        {
            var query = new GetResponseDataByIdQuery { ResponseDataId = id };
            var responseType = await _mediator.Send(query);

            if (responseType == null)
            {
                return NotFound();
            }

            return Ok(responseType);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<string>> CreateResponseData([FromBody] CreateResponseDataCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateResponseData(string id, [FromBody] UpdateResponseDataCommand command)
        {
            command.ResponseDataId = id;
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteResponseData(string id)
        {
            var command = new DeleteResponseDataCommand { ResponseDataId = id };
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }

}
