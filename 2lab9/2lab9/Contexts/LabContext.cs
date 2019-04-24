using _2lab9.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab9.Contexts
{
    public class LabContext : DbContext
    {
        public LabContext() : base("DbConnection") { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
