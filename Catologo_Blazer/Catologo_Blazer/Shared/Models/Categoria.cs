﻿using Catologo_Blazer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catologo_Blazer.Shared
{
   public  class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ICollection<Produto> Produtos { get; set; }

    }
}
