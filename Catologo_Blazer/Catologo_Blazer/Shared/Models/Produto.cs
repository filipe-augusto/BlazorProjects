using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catologo_Blazer.Shared
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "O nome do produto é obrigatorio")]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O nome da descrição é obrigatorio")]
        [MaxLength(260)]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo  preço é obrigatorio")]
        public float Preco { get; set; }
        public string  Imagem { get; set; }

        //indica o relacionamento 
        public int CategoriaId { get; set; }
        //prop de nevação
        public virtual Categoria Categoria { get; set; }

    }
}
