using MediatR;

namespace TemplateDomainDrivenDesign.Application.Features.Task.Query.GetAllTaskForUser
{
    public record GetAllTaskForUserQuery() : IRequest<List<Domain.Entities.Task>>;
    
}
