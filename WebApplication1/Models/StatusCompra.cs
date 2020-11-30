using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class StatusCompra
    {
        [Key]
        public int IdStatus { get; set; }
        public string Status { get; set; }

        public List<Compra> Compra { get; set; }
    }
}
