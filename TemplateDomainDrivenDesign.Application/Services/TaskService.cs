using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Contracts;

namespace CleanArchitecture.Application.Services
{
    public class TaskService : ITaskRepository
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
