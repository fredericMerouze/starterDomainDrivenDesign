using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Application.Common.Exception;
using Todos.Application.Contracts;

namespace Todos.Application.Features.Task.Query
{
    public class GetAllTaskForUserQuery : IRequest<List<Domain.Entities.Task>>
    {

    }

    public class GetAllTaskForUserQueryHandler : IRequestHandler<GetAllTaskForUserQuery, List<Domain.Entities.Task>>
    {
        private readonly ITaskService _taskService;

        public GetAllTaskForUserQueryHandler(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<List<Domain.Entities.Task>> Handle(GetAllTaskForUserQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetAllTaskForUserQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var tasks = _taskService.GetAllTaskForUser();

            return tasks;
        }
    }
}
