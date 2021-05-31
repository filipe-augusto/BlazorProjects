using Catologo_Blazor.Server.Context;
using Catologo_Blazor.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catologo_Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext context;
      
        public ProdutoController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> Get()
        {
            return await context.Produtos.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id}", Name ="GetProduto")]
        public async Task<ActionResult<Produto>> Get (int id)
        {
            return await context.Produtos.FirstOrDefaultAsync(x => x.ProdutoID == id);
        }
        [HttpPost]
        public async Task<ActionResult<Produto>> Post(Produto produto)
        {
            context.Add(produto);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetProduto", new { id = produto.ProdutoID }, produto);
        }
        [HttpPut]
        public async Task<ActionResult<Produto>> Put(Produto produto)
        {
            context.Entry(produto).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(produto);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>>Delete(int id)
        {
            var produto = new Produto { ProdutoID = id };
            context.Remove(produto);
            await context.SaveChangesAsync();
            return Ok(produto);
        }
    }
}
