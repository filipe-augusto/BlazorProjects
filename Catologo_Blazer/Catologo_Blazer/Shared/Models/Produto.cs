using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catologo_Blazer.Shared.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; }
        [MaxLength(260)]
        public string Descricao { get; set; }
        public float Preco { get; set; }
        public string  Imagem { get; set; }
    }
}
