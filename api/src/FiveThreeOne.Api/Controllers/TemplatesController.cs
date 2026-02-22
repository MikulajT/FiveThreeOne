using FiveThreeOne.Application.Common.Models;
using FiveThreeOne.Application.Features.Templates;
using FiveThreeOne.Application.Features.Templates.CreateTemplate;
using FiveThreeOne.Application.Features.Templates.DeleteTemplate;
using FiveThreeOne.Application.Features.Templates.GetTemplate;
using FiveThreeOne.Application.Features.Templates.GetTemplates;
using FiveThreeOne.Application.Features.Templates.UpdateTemplate;
using Microsoft.AspNetCore.Mvc;

namespace FiveThreeOne.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemplatesController : ApiControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TemplateDto>> GetById(Guid id)
        {
            var template = await Mediator.Send(new GetTemplateQuery(id));

            if (template == null) return NotFound();

            return Ok(template);
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<TemplateDto>>> GetPage([FromQuery] PaginationParams pagination)
        {
            var templates = await Mediator.Send(new GetTemplatesQuery(pagination));
            return Ok(templates);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTemplateCommand command)
        {
            var templateId = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = templateId }, templateId);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateTemplateCommand command)
        {
            if (id != command.Id) return BadRequest("ID mismatch");

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteTemplateCommand(id));
            return Ok();
        }
    }
}
