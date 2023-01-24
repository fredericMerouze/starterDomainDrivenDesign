namespace CleanArchitecture.Application.Contracts.Services
{
    public interface ITaskService
    {
        List<Domain.Entities.Task> GetAllTaskForUser();
    }
}
