using CleanArchitecture.Domain.Primitives;

namespace CleanArchitecture.Domain.Entities
{
    public sealed class Task : Entity
    {
        public Task(Guid id, string description) : base(id)
        {
            Description = description;
        }
        public string Description { get; set; }
    }
}
