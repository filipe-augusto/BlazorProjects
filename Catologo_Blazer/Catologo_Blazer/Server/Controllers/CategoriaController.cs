using Catologo_Blazer.Server.Context;
using Catologo_Blazer.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catologo_Blazer.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext context;
        public CategoriaController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task <ActionResult<List<Categoria>>> Get()
        {
            return await context.Categoria.AsNoTracking().ToListAsync();
            //asnotracking desabilita o rastreamento das entidades e obtem um desempenho melhor
        }
        [HttpGet("{id}",Name ="GetCategoria")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            return await context.Categoria.FirstOrDefaultAsync(x => x.CategoriaId == id);
        }
        [HttpPost]
        public async Task<ActionResult<Categoria>> Post (Categoria categoria)
        {
            context.Add(categoria);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetCategoria",
                new { id = categoria.CategoriaId }, categoria);
        }
        [HttpPut]
        public async Task<ActionResult<Categoria>> Put (Categoria categoria)
        {
            context.Entry(categoria).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(categoria);
        }
        [HttpDelete]
        public async Task<ActionResult<Categoria>>Delete (int id)
        {
            var categoria = new Categoria { CategoriaId = id };
            context.Remove(categoria);
            await context.SaveChangesAsync();
            return Ok(categoria);
        }
 
    }
}
