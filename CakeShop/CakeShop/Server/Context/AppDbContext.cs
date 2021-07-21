using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace CakeShop.Server.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Cake> Cake { get; set; }

    }
}
