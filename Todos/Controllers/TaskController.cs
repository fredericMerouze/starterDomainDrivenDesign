using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todos.Application.Features.Task.Query;

namespace Todos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTaskForUser()
        {
            var query = new GetAllTaskForUserQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
