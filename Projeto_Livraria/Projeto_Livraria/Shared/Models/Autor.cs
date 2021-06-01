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
        [MaxLength(100)]
        public string Nome { get; set; }
        [MaxLength(100)]
        public string Nacionalidade { get; set; }
        public ICollection<Livro> Livros { get; set; }
    }
}
