using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Application.Contracts
{
    public interface ITaskService
    {
        List<Domain.Entities.Task> GetAllTaskForUser();
    }
}
