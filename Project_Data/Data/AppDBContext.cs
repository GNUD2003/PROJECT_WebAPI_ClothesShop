using Microsoft.EntityFrameworkCore;
using Project_Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Data.Data
{
    public class AppDBContext : DbContext, IAppDBContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<ConfirmEmail> ConfirmEmails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Materials> Materials { get; set; }
        

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public AppDBContext() { }

        public DbSet<T> SetEntity<T>() where T : class
        {
            return base.Set<T>();

        }

        public async Task<int> CommitChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships using Fluent API


            SeedData.Seed(modelBuilder);

        }
    }
}
