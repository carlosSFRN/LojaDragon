using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Quadrinho
    {
        [Key]
        public int IdQuadrinho { get; set; }

        [Required(ErrorMessage = "O campo 'Título' é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Título")]
        [StringLength(30, MinimumLength = 1)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo 'Descrição' é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Descrição")]
        [StringLength(100, MinimumLength = 10)]
        public string Descricao { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        [NotMapped]
        [Column(TypeName = "varchar(200)")]
        [Display(Name = "Capa")]

        public IFormFile CaminhoCapa { get; set; }

        public string CaminhoFisicoCapa { get; set; }

        //public List<Compra> Compra { get; set; }
    }
}
