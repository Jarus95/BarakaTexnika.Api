using System;
using Xeptions;

namespace BarakaTexnika.Api.Models.Employees.Exceptions
{
    public class NotFoundEmployeeException : Xeption
    {
        public NotFoundEmployeeException(Guid id)
            : base($"Couldn't find employee with id: {id}")
        { }
    }
}
