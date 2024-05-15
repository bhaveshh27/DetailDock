using DetailDock.Core.Application.Features.Question.Command;
using DetailDock.Core.Application.Features.Question.DTO;
using DetailDock.Core.Application.Features.Question.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DetailDock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<QuestionDTO>>> GetAllQuestions()
        {
            var query = new GetAllQuestionsQuery();
            var Questions = await _mediator.Send(query);
            return Ok(Questions);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<QuestionDTO>> GetQuestionById(string id)
        {
            var query = new GetQuestionByIdQuery { QuestionId = id };
            var Question = await _mediator.Send(query);

            if (Question == null)
            {
                return NotFound();
            }

            return Ok(Question);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<string>> CreateQuestion([FromBody] CreateQuestionCommand command)
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
        public async Task<IActionResult> UpdateQuestion(string id, [FromBody] UpdateQuestionCommand command)
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
        public async Task<IActionResult> DeleteQuestion(string id)
        {
            var command = new DeleteQuestionCommand { QuestionId = id };
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
