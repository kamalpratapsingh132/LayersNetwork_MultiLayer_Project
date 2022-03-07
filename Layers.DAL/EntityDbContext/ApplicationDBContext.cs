
using LayerNetwork.Model.AdminModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Layers.DAL.EntityDbContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeModel> EmployeeModels { get; set; }
    }
}
