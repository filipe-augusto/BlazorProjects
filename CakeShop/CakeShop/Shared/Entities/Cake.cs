using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Shared.Entities
{
    public class Cake
    {
        [Key]
        public int IdCake { get; set; }
        [Required(ErrorMessage = "O campo sabor é obrigatório")]
        [MaxLength(100)]
        public string Flavor { get; set; }
        [Required(ErrorMessage = "O campo preço é obrigatório")]      
        public decimal Price { get; set; }
        [Required(ErrorMessage = "O campo peso é obrigatório")]
        public decimal Weight { get; set; }
        [Required]
        public DateTime PreparationDate { get; set; }
        [Required(ErrorMessage = "O campo dias para vender é obrigatório")]

        public int DaysToExpiration { get; set; }

    }
}
