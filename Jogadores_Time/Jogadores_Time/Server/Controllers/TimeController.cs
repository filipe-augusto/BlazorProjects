using Jogadores_Time.Server.Context;
using Jogadores_Time.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jogadores_Time.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly AppDbContext context;

        public TimeController (AppDbContext context)
        {
            this.context = context; 
        }
        [HttpGet("todos")]
        public async Task<ActionResult<List<Time>>> Get()
        {
            try
            {

            return await context.Time.ToListAsync();
            }
            catch (Exception e)
            {
                return Ok("erro");
              
            }
        }
        [HttpGet("{id}",Name ="GetTime")]
        public async Task<ActionResult<Time>> Get(int id)
        {
            return await context.Time.FirstOrDefaultAsync(x => x.TimeId == id);
        }

        [HttpPost]
        public async Task<ActionResult<Time>> Post(Time time)
        {
            context.Add(time);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetTime", new { id = time.TimeId }, time);
        }

        [HttpPut]
        public async Task<ActionResult<Time>> Put (Time time)
        {
            context.Entry(time).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(time);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Time>> Delete(int id)
        {
            var time = new Time { TimeId = id };
            context.Remove(time);
            await context.SaveChangesAsync();
            return Ok(time);
       
        }


    }
}
