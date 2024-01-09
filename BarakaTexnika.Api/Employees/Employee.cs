using System;

namespace BarakaTexnika.Api.Employees
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
    }
}
