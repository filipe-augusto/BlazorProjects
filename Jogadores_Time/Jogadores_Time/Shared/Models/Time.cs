using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Jogadores_Time.Shared.Models
{
  public  class Time
    {
        [Key]
        public int TimeId { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; }
        [MaxLength(200)]
        public string Descricao { get; set; }
        [MaxLength(15)]
        public string Estado { get; set; }
        public int QuantidadeDeTitulos { get; set; }

        public string ImagemURL { get; set; }
        public List<Jogadores> Jogadores { get; set; }

    }
}
