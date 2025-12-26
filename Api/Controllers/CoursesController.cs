using Application.Courses.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CoursesController(IMediator mediator) => _mediator = mediator;

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateCourseCommand command)
        {
            command.CourseId = id;

            await _mediator.Send(command);
            return NoContent();
        }
    }
}
