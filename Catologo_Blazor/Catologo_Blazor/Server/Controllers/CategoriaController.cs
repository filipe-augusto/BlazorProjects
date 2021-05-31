using Catologo_Blazor.Server.Context;
using Catologo_Blazor.Server.Utils;
using Catologo_Blazor.Shared.Models;
using Catologo_Blazor.Shared.Recursos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




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
namespace Blazor_Catalogo.Server.Controllers
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
        public async Task<ActionResult<List<Categoria>>> Get([FromQuery]Paginacao paginacao)
        {
            var queryable = context.Categorias.AsQueryable();
            await HttpContext.InserirParametroEmPageResponse(queryable, paginacao.QuantidadePorPagina);
            return await queryable.Paginar(paginacao).ToListAsync();
        //    return await context.Categorias.AsNoTracking().ToListAsync();
        
        }

        [HttpGet("{id}", Name = "GetCategoria")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            return await context.Categorias.FirstOrDefaultAsync(x => x.CategoriaID == id);
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria)
        {
            context.Add(categoria);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetCategoria", new { id = categoria.CategoriaID }, categoria);
        }

        [HttpPut]
        public async Task<ActionResult<Categoria>> Put(Categoria categoria)
        {
            context.Entry(categoria).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            var categoria = new Categoria { CategoriaID = id };
            context.Remove(categoria);
            await context.SaveChangesAsync();
            return Ok(categoria);
        }
    }
}
