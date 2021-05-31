using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Livraria.Shared.Models
{
   public class Livro
    {
        public int LivroId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeDePaginas { get; set; }
        public  string ImagemURL { get; set; }
        public int AutorId { get; set; }
        public virtual Autor Autor { get; set; }
    }
}
