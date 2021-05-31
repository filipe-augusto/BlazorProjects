using Catologo_Blazer.Shared;
using Catologo_Blazer.Shared.Models;
using Microsoft.EntityFrameworkCore;


namespace Catologo_Blazer.Server.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produtos { get; set; } 
    }
}
