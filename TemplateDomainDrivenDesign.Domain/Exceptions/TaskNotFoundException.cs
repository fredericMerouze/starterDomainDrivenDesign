using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDomainDrivenDesign.Domain.Exceptions.Base;

namespace TemplateDomainDrivenDesign.Domain.Exceptions
{
    public sealed class TaskNotFoundException : NotFoundException
    {
        public TaskNotFoundException(Guid taskId) 
            : base($"The task with the identifier {taskId} was not found")
        {

        }
    }
}
