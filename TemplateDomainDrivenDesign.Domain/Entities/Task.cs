using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDomainDrivenDesign.Domain.Primitives;

namespace TemplateDomainDrivenDesign.Domain.Entities
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
