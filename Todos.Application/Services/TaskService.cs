using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Application.Contracts;

namespace Todos.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly IApplicationDbContext _context;

        public TaskService(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<Domain.Entities.Task> GetAllTaskForUser()
        {
            return _context.Tasks.ToList();
        }
    }
}
