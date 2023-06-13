namespace CleanArchitecture.Domain.Contracts.Repositories;
public interface ITaskRepository
{
    List<Entities.Task> GetAllTaskForUser();
}