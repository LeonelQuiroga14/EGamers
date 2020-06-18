using Gamers.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gamers.Web.Models
{
    public class CategoriaViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        [StringLength(50, ErrorMessage = "El campo debe contener entre {2} y {1} caracteres.", MinimumLength = 3)]
        [Display(Name = "Genero")]
        public string Descripcion { get; set; }
        [Display(Name = "Edadd Min.")]
        public int? EdadMinima { get; set; }

        public virtual List<JuegoViewModel> Juegos { get; set; }
        public CategoriaViewModel()
        {

        }

        public CategoriaViewModel(Categoria entity)
        {
            this.Id = entity.Id;
            this.Descripcion = entity.Descripcion;
            EdadMinima = entity.EdadMinima ?? 0;
          //  this.Juegos = entity.Juegos.Select(x => new JuegoViewModel(x)).ToList();
        }

        public Categoria ToEntity() 
        {
            return new Categoria() {
                Id = this.Id,
                Descripcion = this.Descripcion,
                EdadMinima = this.EdadMinima
            };
        }
    }
}