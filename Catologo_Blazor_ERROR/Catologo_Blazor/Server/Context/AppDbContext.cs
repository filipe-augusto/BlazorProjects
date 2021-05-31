using Microsoft.EntityFrameworkCore;

using Catologo_Blazor.Shared.Models;


namespace Catologo_Blazor.Server.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        //add-migration Inicial
        //update-database
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
