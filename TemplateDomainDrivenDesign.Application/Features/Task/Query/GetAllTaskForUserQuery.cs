using MediatR;
using TemplateDomainDrivenDesign.Application.Contracts;

namespace TemplateDomainDrivenDesign.Application.Features.Task.Query
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
            var tasks = _taskService.GetAllTaskForUser();

            return tasks;
        }
    }
}
