using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Livraria.Shared.Models
{
   public class Autor
    {
        public int AutorId { get; set; }
        [Required(ErrorMessage ="Campo nome é obrigatorio.")]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "campo nascionalidade é obrigatorio.")]
        [MaxLength(100)]
        public string Nacionalidade { get; set; }
        public ICollection<Livro> Livros { get; set; }
    }
}
