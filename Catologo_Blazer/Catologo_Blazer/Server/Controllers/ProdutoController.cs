using Catologo_Blazer.Server.Context;
using Catologo_Blazer.Server.Utils;
using Catologo_Blazer.Shared;
using Catologo_Blazer.Shared.Recursos;
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
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext context;
        public ProdutoController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet("categorias/{id:int}")]
        public async Task<ActionResult<List<Produto>>> GetProdutoCategoria(int id)
        {
            return await context.Produtos.Where(p => p.CategoriaId == id).ToListAsync();
        }

        public async Task<ActionResult<List<Produto>>> Get([FromQuery] Paginacao paginacao, [FromQuery] string nome)
        {
            var queryable = context.Produtos.AsQueryable();
            if (!string.IsNullOrEmpty(nome))
            {
                queryable = queryable.Where(x => x.Nome.Contains(nome));
            }
            //   var queryable = context.Categorias.AsQueryable();
            await HttpContext.InserirParametroEmPageResponse(queryable, paginacao.QuantidadePorPagina);
            return await queryable.Paginar(paginacao).ToListAsync();
        }

        //RETORNAR UMA LISTA DE PRODUTOS
        [HttpGet("todos")]
        public async Task<ActionResult<List<Produto>>> Get()
        {
            return await context.Produtos.AsNoTracking().ToListAsync();
        }

        //RETORNAR UM PRODUTO IGUAL AO ID PASSADO PELO PARAMETRO
        [HttpGet("{id}",Name ="GetProduto")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            var registro = await context.Produtos.FirstOrDefaultAsync(x => x.ProdutoId == id);
            return registro;
        }

        //CRIAR OU ADICIONAR UM NOVO PRODUTO
        [HttpPost]
        public async Task<ActionResult<Produto>> Post(Produto produto)
        {
            context.Add(produto);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetProduto", new { id = produto.ProdutoId }, produto);
        }
        //EDITAR UM PRODUTO
        public async Task <ActionResult<Produto>> Put(Produto produto)
        {
            context.Entry(produto).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(produto);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> Delete(int id)
        {
            var produto = new Produto { ProdutoId = id };
            context.Remove(produto);
            await context.SaveChangesAsync();
            return Ok(produto);

        }



    }
}
