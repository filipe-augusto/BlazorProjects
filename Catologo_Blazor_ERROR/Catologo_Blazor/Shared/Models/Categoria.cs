
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Catologo_Blazor.Shared.Models
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        [Required(ErrorMessage ="O nome da caregoria é obrigatorio")]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo da descrição é obrigatorio")]
        [MaxLength(200)]
        public string Descricao { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
