namespace TemplateDomainDrivenDesign.Application.Contracts
{
    public interface ITaskRepository
    {
        List<Domain.Entities.Task> GetAllTaskForUser();
    }
}
