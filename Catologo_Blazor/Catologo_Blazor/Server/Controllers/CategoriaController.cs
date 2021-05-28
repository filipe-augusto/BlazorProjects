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

//    MEOTODOS HTTPCLIENT

//getAsync() GET
//getByteArrayAsync   GET
//getStreamAsync  GET
//getstringAsync  GET
//postAsync POST
//putAsync PUT
//deleteAsync DELETE
//DeleteAsync DELETE
//SendAsync TODOS
//---------------------------------------------
//METODOS HELPER HTTP JSON
//getJsonAsync GET -obter
//PostJsonAsync POST - crirar
//PutJsonAsync PUT - editar
//SENDASYNC todos - qualquer um


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
        public async Task<ActionResult<List<Categoria>>> Get()//retorna uma lista de categoria
        {
            return await context.Categorias.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id}", Name = "GetCategoria")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            return await context.Categorias.FirstOrDefaultAsync(x => x.CategoriaID == id);
        }
        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria) //incluir
        {
            context.Add(categoria);  //add no context que é a sessão com o banco
            await context.SaveChangesAsync();  //salva
            return new CreatedAtRouteResult("GetCategoria", //retorna a categoria que foi incluida
                new { id = categoria.CategoriaID }, categoria);
        }
        [HttpPut]
        public async Task<ActionResult<Categoria>> Put(Categoria categoria) //alterar
        {
            context.Entry(categoria).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(categoria);
        }
        [HttpDelete]
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> Delete (int id)
        {
            var categoria = new Categoria { CategoriaID = id };
            context.Remove(categoria);
            return Ok("{id}");
        }
    }
}
