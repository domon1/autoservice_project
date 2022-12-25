using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EFDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<CarService> CarServices { get; set; }
        public DbSet<Sparepart> Spareparts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<TimeOrder> TimeOrders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        public EFDbContext(DbContextOptions<EFDbContext> options): base(options) { }

        /// summary
        /// For migrations
        /// summary
        public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDbContext>
        {
            public EFDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<EFDbContext>();
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CarCourseDb;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataLayer"));

                return new EFDbContext(optionsBuilder.Options);
            }
        }
    }
}
