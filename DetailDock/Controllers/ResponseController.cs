using DetailDock.Core.Application.Features.Response.Command;
using DetailDock.Core.Application.Features.Response.DTO;
using DetailDock.Core.Application.Features.Response.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DetailDock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResponseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResponseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ResponseDTO>>> GetAllResponses()
        {
            var query = new GetAllResponsesQuery();
            var responses = await _mediator.Send(query);
            return Ok(responses);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<ResponseDTO>> GetResponseById(string id)
        {
            var query = new GetResponseByIdQuery { ResponseId = id };
            var response = await _mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<string>> CreateResponse([FromBody] CreateResponseCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateResponse(string id, [FromBody] UpdateResponseCommand command)
        {
            command.ResponseId = id;
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
        public async Task<IActionResult> DeleteResponse(string id)
        {
            var command = new DeleteResponseCommand { ResponseId = id };
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
