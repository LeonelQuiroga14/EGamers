using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamers.DataAccess.Models
{
    
     public  class Categoria
     {   
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo debe contener entre {2} y {1} caracteres.", MinimumLength = 3)]
        [Display(Name = "Nombre de categoria")]
        public string Descripcion { get; set; }      
        public int? EdadMinima { get; set; }
     }
}
