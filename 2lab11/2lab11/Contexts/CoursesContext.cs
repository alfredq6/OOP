using _2lab11.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab11.Contexts
{
    public class CoursesContext : DbContext
    {
        public CoursesContext() : base("DbConnection") { }

        public DbSet<Subject> Subjects { get; set; }
    }
}
