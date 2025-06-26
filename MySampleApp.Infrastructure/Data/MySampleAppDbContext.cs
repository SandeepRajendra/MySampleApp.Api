using Microsoft.EntityFrameworkCore;
using MySampleApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySampleApp.Infrastructure.Data
{
    public class MySampleAppDbContext(DbContextOptions<MySampleAppDbContext> options) : DbContext(options)
    {
        public DbSet<ProductEntity> Products { get; set; }
    }
}
