using Application.Enrollments.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EnrollmentsController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Enroll([FromBody] EnrollStudentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
