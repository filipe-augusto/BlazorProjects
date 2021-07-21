using CakeShop.Server.Context;
using CakeShop.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakeController : ControllerBase
    {
        private readonly AppDbContext context;
        public CakeController(AppDbContext context)
        { this.context = context; }

        [HttpGet]
        public async Task<ActionResult<List<Cake>>> Get()
        {
            try
            {
                var cakes = await context.Cake.AsNoTracking().ToListAsync();
                return Ok(cakes);
            }
            catch 
            {

                throw;
            }
           // return await context.Cake.AsNoTracking().ToListAsync();
            //asnotracking desabilita o rastreamento das entidades e obtem um desempenho melhor
        }

        [HttpGet("{id}", Name = "GetCake")]
        public async Task<ActionResult<Cake>> Get(int id)
        { return await context.Cake.FirstOrDefaultAsync(x => x.IdCake == id); }
      [HttpPost]
        public async Task<ActionResult<Cake>> Post(Cake cake)
        {
            cake.PreparationDate = DateTime.Now;
            context.Add(cake);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetCake",
                new { id = cake.IdCake }, cake);
        }
        [HttpPut]
        public async Task<ActionResult<Cake>> Put(Cake cake)
        {
            context.Entry(cake).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(cake);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cake>>Delete (int id)
        {
            var cake = new Cake { IdCake = id };
        context.Remove(cake);
            await context.SaveChangesAsync();
            return Ok(cake);
    }



}
}
