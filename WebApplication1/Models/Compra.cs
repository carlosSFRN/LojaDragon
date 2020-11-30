using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Compra
    {
        [Key]
        public int IdCompra { get; set; }
        public Quadrinho Quadrinho { get; set; }
        public string Titulo { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public StatusCompra StatusCompra { get; set; }
        public string Usuario { get; set; }
    }
    
}
