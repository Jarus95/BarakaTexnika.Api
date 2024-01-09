using System;
using Xeptions;

namespace BarakaTexnika.Api.Models.Employees.Exceptions
{
    public class FailedEmployeeStorageException : Xeption
    {
        public FailedEmployeeStorageException(Exception innerException)
            : base("Failed employee storage error occured, fix the error", innerException)
        { }
    }
}
