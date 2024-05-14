using DetailDock.Core.Application.Features.Program.Command;
using DetailDock.Core.Application.Features.Program.DTO;
using DetailDock.Core.Application.Features.Program.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DetailDock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProgramController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ProgramDTO>>> GetAllPrograms()
        {
            var query = new GetAllProgramQuery();
            var programs = await _mediator.Send(query);
            return Ok(programs);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<ProgramDTO>> GetProgramById(int id)
        {
            var query = new GetProgramByIdQuery { ProgramId = id };
            var program = await _mediator.Send(query);

            if (program == null)
            {
                return NotFound();
            }

            return Ok(program);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<int>> CreateProgram([FromBody] CreateProgramCommand command)
        {
            var programId = await _mediator.Send(command);
            return Ok(programId);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProgram(int id, [FromBody] UpdateProgramCommand command)
        {
            command.ProgramId = id;
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
        public async Task<IActionResult> DeleteProgram(int id)
        {
            var command = new DeleteProgramCommand { ProgramId = id };
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
