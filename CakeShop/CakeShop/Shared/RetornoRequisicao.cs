using System;
using System.Collections.Generic;
using System.Text;

namespace CakeShop.Shared.Entidades
{
   public class RetornoRequisicao
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public IEnumerable<string> Erros { get; set; }
    }
}
