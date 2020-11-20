using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Quadrinho
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Título' é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Título")]
        [StringLength(30, MinimumLength = 1)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo 'Descrição' é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Descrição")]
        [StringLength(100, MinimumLength = 10)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo 'Preço' é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo 'Capa' é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Capa")]
        public string CaminhoCapa { get; set; }
    }
}
