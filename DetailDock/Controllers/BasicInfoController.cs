using DetailDock.Core.Application.Features.BasicInfo.Command;
using DetailDock.Core.Application.Features.BasicInfo.DTO;
using DetailDock.Core.Application.Features.BasicInfo.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DetailDock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasicInfoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasicInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<BasicInfoDTO>>> GetAllBasicInfo()
        {
            var query = new GetAllBasicInfoQuery();
            var BasicInfos = await _mediator.Send(query);
            return Ok(BasicInfos);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<BasicInfoDTO>> GetBasicInfoById(int id)
        {
            var query = new GetBasicInfoByIdQuery { BasicInfoId = id };
            var BasicInfo = await _mediator.Send(query);

            if (BasicInfo == null)
            {
                return NotFound();
            }

            return Ok(BasicInfo);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<int>> CreateBasicInfo([FromBody] CreateBasicInfoCommand command)
        {
            var BasicInfoId = await _mediator.Send(command);
            return Ok(BasicInfoId);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateBasicInfo(int id, [FromBody] UpdateBasicInfoCommand command)
        {
            command.BasicInfoId = id;
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
        public async Task<IActionResult> DeleteBasicInfo(int id)
        {
            var command = new DeleteBasicInfoCommand { BasicInfoId = id };
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
