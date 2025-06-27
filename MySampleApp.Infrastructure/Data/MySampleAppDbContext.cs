using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySampleApp.Domain.Entities;
using MySampleApp.Infrastructure.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySampleApp.Infrastructure.Data
{
    //public class MySampleAppDbContext(DbContextOptions<MySampleAppDbContext> options) : DbContext(options)
    //{
    //    public DbSet<ProductEntity> Products { get; set; }
    //}
    public class MySampleAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public MySampleAppDbContext(DbContextOptions<MySampleAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // You can customize Identity or ProductEntity mappings here
            builder.Entity<ProductEntity>()
           .Property(p => p.Price)
           .HasPrecision(18, 2); // 🔧 Add this line
        }
    }
}
