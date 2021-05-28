

using System.ComponentModel.DataAnnotations;

namespace Catologo_Blazor.Shared.Models
{
   public  class Produto
    {
        public int ProdutoID { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; }
        [MaxLength(200)]
        public string Descricao { get; set; }

        public float Preco { get; set; }
        [MaxLength(260)]
        public string ImagemUrl { get; set; }
        //indica o relacionamento
        public int CategoriaID { get; set; }
        //prop de navegação
        public virtual Categoria Categoria { get; set; }
    }
}
