using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Contracts;
using CleanArchitecture.Application.Contracts.Services;

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
