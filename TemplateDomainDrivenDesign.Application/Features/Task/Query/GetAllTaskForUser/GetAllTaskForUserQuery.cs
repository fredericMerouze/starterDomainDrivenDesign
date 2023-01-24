using MediatR;

namespace CleanArchitecture.Application.Features.Task.Query.GetAllTaskForUser
{
    public record GetAllTaskForUserQuery() : IRequest<List<Domain.Entities.Task>>;
    
}
