using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Livraria.Shared.Models
{
   public class Autor
    {
        public int AutorId { get; set; }
        public string Nome { get; set; }
        public string Nacionalidade { get; set; }
        public ICollection<Livro> Livros { get; set; }
    }
}
