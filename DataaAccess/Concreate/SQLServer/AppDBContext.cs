using Core.Configration;
using Core.Entities.Concreate;
using Entities.Concreate;
using Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataaAccess.Concreate.SQLServer
{
    public class AppDBContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DataBaseConfigration.ConnectionString);

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<User> AppUser { get; set; }
        public DbSet<AppRole> AppRole { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<WishList> WishLists { get; set; }
    }
}

