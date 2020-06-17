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
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Requerimientos { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}")]
        public DateTime FechaLanzamiento { get; set; }
        public double Precio { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaViewModel Categoria { get; set; }
        public List<HttpPostedFileBase> Image { get; set; }
        //public List<HttpPostedFileBase> Images { get; set; }

        public JuegoViewModel()
        {

        }
        public JuegoViewModel(Juego entity)
        {
            this.Id = entity.Id;
            this.Descripcion = entity.Descripcion;
            this.FechaLanzamiento = entity.FechaLanzamiento;
            this.Precio = entity.Precio;
            this.CategoriaId = entity.CategoriaId;
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
            CategoriaId = this.CategoriaId
           };

        }
    }
}