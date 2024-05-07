using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeControlWebAPI.Model;

namespace EmployeeControlWebAPI.Data
{
    public class EmployeeControlWebAPIContext : DbContext
    {
        public EmployeeControlWebAPIContext (DbContextOptions<EmployeeControlWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeControlWebAPI.Model.Employees> Employees { get; set; } = default!;

        public DbSet<EmployeeControlWebAPI.Model.Shifts> Shifts { get; set; } = default!;
    }
}
