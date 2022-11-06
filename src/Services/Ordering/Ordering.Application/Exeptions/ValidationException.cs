﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Exeptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException() : base("One or more validation failures have occurred")
        {
            Error = new Dictionary<string, string[]>();
        }
        public ValidationException(IEnumerable<ValidationFailure> failures) :this()
        {
            Error = failures
                    .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                    .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
        public Dictionary<string, string[]> Error { get;  }
    }
}
