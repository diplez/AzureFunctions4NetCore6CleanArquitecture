using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Blog.Service.BlogApi.Application.Exceptions
{
    public class ApplicationException : Exception
    {
        public ApplicationException(string message) : base(message)
        {
        }
        public ApplicationException(IEnumerable<ValidationFailure> failures)
            : base(string.Join(", ", failures))
        {
        }
    }
}
