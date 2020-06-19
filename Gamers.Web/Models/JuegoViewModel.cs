using Gamers.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gamers.Web.Models
{
    public class JuegoViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Juego")]
        public string Nombre { get; set; }
        [Display(Name = "Desc.")]
        public string Descripcion { get; set; }
        [Display(Name = "Requ.")]
        public string Requerimientos { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        [Display(Name = "Lanzamiento")]
        public DateTime FechaLanzamiento { get; set; }
        [Display(Name = "Precio")]
        public double Precio { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaViewModel Categoria { get; set; }
        public List<HttpPostedFileBase> Image { get; set; }
        public List<ImagenJuegoViewModel> Images { get; set; }

        public JuegoViewModel()
        {

        }
        public JuegoViewModel(Juego entity)
        {
            this.Id = entity.Id;
            this.Nombre = entity.Nombre;
            this.Descripcion = entity.Descripcion;
            this.FechaLanzamiento = entity.FechaLanzamiento;
            this.Requerimientos = entity.Requerimientos;
            this.Precio = entity.Precio;
            this.CategoriaId = entity.CategoriaId;
            if(entity.Categoria!=null)
            this.Categoria = new CategoriaViewModel(entity.Categoria);

        }

        public Juego ToEntity()
        {
            return new Juego() {
            Id = this.Id,
            Descripcion = this.Descripcion,
            FechaLanzamiento = this.FechaLanzamiento,
            Precio = this.Precio,
            Nombre= this.Nombre,
            Requerimientos= this.Requerimientos,
            CategoriaId = this.CategoriaId
           };

        }
    }
}