using Catologo_Blazer.Server.Context;
using Catologo_Blazer.Shared.Models;
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
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext context;
        public ProdutoController(AppDbContext context)
        {
            this.context = context;
        }
        //RETORNAR UMA LISTA DE PRODUTOS
        [HttpGet]
        public async Task<ActionResult<List<Produto>>> Get()
        {
            return await context.Produtos.AsNoTracking().ToListAsync();
        }

        //RETORNAR UM PRODUTO IGUAL AO ID PASSADO PELO PARAMETRO
        [HttpGet("{id}",Name ="GetProduto")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            return await context.Produtos.FirstOrDefaultAsync(x => x.ProdutoId == id);
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

    }
}
