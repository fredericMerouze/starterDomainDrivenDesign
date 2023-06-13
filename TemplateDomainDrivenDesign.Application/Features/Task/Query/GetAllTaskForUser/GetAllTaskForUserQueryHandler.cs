using MediatR;
using CleanArchitecture.Domain.Contracts.Repositories;
using CleanArchitecture.Application.Features.Task.Query.GetAllTaskForUser;

namespace CleanArchitecture.Application.Features.Task.Query
{
    public class GetAllTaskForUserQueryHandler : IRequestHandler<GetAllTaskForUserQuery, List<Domain.Entities.Task>>
    {
        private readonly ITaskRepository _taskRepository;

        public GetAllTaskForUserQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<Domain.Entities.Task>> Handle(GetAllTaskForUserQuery request, CancellationToken cancellationToken)
        {
            var tasks = _taskRepository.GetAllTaskForUser();

            return tasks;
        }
    }
}
