using CleanArchitecture.Application.Contracts.Services;
using CleanArchitecture.Domain.Contracts.Repositories;

namespace CleanArchitecture.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public List<Domain.Entities.Task> GetAllTaskForUser()
        {
            return _repository.GetAllTaskForUser();
        }
    }
}
