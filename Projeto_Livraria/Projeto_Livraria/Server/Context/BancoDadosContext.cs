using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Livraria.Shared.Models;

namespace Projeto_Livraria.Server.Context
{
    public class BancoDadosContext : DbContext
    {
        public BancoDadosContext(DbContextOptions<BancoDadosContext> options) : base(options) { }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
    }
   

}
