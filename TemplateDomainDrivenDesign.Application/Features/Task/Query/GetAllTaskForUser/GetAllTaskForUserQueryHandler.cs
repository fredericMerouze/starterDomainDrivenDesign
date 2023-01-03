using MediatR;
using TemplateDomainDrivenDesign.Application.Contracts;
using TemplateDomainDrivenDesign.Application.Features.Task.Query.GetAllTaskForUser;

namespace TemplateDomainDrivenDesign.Application.Features.Task.Query
{
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
