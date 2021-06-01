﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Livraria.Server.Context;
using Projeto_Livraria.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Livraria.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly BancoDadosContext context;
        public AutorController(BancoDadosContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()//retorna todos
        {
            return await context.Autores.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id}",Name ="GetAutor")]//retorna um
        public async Task<ActionResult<Autor>> Get(int id)
        {
            return await context.Autores.FirstOrDefaultAsync(x => x.AutorId == id);
        }
        [HttpPost]//adicionar
        public async Task<ActionResult<Autor>> Post (Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetAutor", new { id = autor.AutorId }, autor);
        }
        [HttpPut]//alterar
        public async Task<ActionResult<Autor>> Put(Autor autor)
        {
            context.Entry(autor).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(autor);
        }
        [HttpDelete]
        public async Task<ActionResult<Autor>> Delete(int id)
        {
            var autor = new Autor { AutorId = id };
            context.Remove(autor);
            await context.SaveChangesAsync();
            return Ok(autor);
        }
        
    }
}
