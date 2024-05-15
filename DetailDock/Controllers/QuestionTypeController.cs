using DetailDock.Core.Application.Features.QuestionType.Command;
using DetailDock.Core.Application.Features.QuestionType.DTO;
using DetailDock.Core.Application.Features.QuestionType.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DetailDock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<QuestionTypeDTO>>> GetAllQuestionTypes()
        {
            var query = new GetAllQuestionTypesQuery();
            var questionTypes = await _mediator.Send(query);
            return Ok(questionTypes);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<QuestionTypeDTO>> GetQuestionTypeById(string id)
        {
            var query = new GetQuestionTypeByIdQuery { QuestionTypeId = id };
            var questionType = await _mediator.Send(query);

            if (questionType == null)
            {
                return NotFound();
            }

            return Ok(questionType);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<string>> CreateQuestionType([FromBody] CreateQuestionTypeCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Ok(response.Message);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateQuestionType(string id, [FromBody] UpdateQuestionTypeCommand command)
        {
            command.Id = id;
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
        public async Task<IActionResult> DeleteQuestionType(string id)
        {
            var command = new DeleteQuestionTypeCommand { QuestionTypeId = id };
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
