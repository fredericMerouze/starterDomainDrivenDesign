using CleanArchitecture.Domain.Contracts.Repositories;

namespace CleanArchitecture.Persistence.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Domain.Entities.Task> GetAllTaskForUser()
        {
            return _context.Set<Domain.Entities.Task>().ToList();
        }
    }
}
