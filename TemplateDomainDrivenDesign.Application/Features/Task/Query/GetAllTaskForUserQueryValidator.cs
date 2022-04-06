using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateDomainDrivenDesign.Application.Features.Task.Query
{
    public class GetAllTaskForUserQueryValidator : AbstractValidator<GetAllTaskForUserQuery>
    {
        public GetAllTaskForUserQueryValidator()
        {

        }
    }
}
