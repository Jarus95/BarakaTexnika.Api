using BarakaTexnika.Api.Employees;
using Microsoft.EntityFrameworkCore;

namespace BarakaTexnika.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Employee> Employee { get; set; }
    }
}
