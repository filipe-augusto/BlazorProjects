using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Jogadores_Time.Shared.Models
{
   public class Jogadores
    {
        [Key]
        public int JogadorId { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; }
        [MaxLength(150)]
        public string  Naturalidade { get; set; }
        [MaxLength(50)]
        public int Posicao { get; set; }
        public int Idade { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }
        public decimal IMC { get { return (Peso/(Altura*Altura));}}
        public int TimeId { get; set; }
        public virtual Time Time { get; set; }
    }
}
