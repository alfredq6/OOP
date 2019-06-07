using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class GSContext : DbContext
    {
        public GSContext() : base("DbConnection") { }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<GasStation> GasStations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Company>().HasMany(x => x.ListGasStations).WithRequired(x => x.Company);
            modelBuilder.Entity<GasStation>().HasMany(x => x.ListFeedbacks).WithRequired(x => x.GasStation);
            modelBuilder.Entity<User>().HasMany(x => x.ListFeedbacks).WithRequired(x => x.User);
        }
    }
}
