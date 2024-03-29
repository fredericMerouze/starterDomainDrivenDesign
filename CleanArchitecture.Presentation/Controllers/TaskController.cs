﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Features.Task.Query.GetAllTaskForUser;

namespace CleanArchitecture.Presentation.Controllers
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
            var result = await _mediator.Send(new GetAllTaskForUserQuery());

            return Ok(result);
        }
    }
}
