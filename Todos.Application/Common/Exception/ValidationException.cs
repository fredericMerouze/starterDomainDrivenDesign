using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Application.Common.Exception
{
    public class ValidationException : ApplicationException
    {
        public List<string> ValidationErrors { get; set; }
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException()
            : base("One or more validation failures have occured.")
        {
            Errors = new Dictionary<string, string[]>();
        }
        public ValidationException(ValidationResult validationResult)
        {
            Errors = validationResult.Errors
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());

            ValidationErrors = new List<string>();

            foreach (var validationError in validationResult.Errors)
            {
                ValidationErrors.Add(validationError.ErrorMessage);
            }

        }
    }
}
