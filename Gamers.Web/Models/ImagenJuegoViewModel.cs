using Gamers.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamers.Web.Models
{
    public class ImagenJuegoViewModel
    {
        public int Id { get; set; }
        public byte[] Imagen { get; set; }
        public string ImageName { get; set; }
        public bool IsActive { get; set; }
        public int JuegoId { get; set; }

        public ImagenJuegoViewModel()
        {

        }

        public ImagenJuegoViewModel(ImagenesJuego entity)
        {
            this.Id = entity.Id;
            this.Imagen = entity.Imagen;
            this.ImageName = entity.ImageName;
            this.IsActive = entity.IsActive;
            this.JuegoId = entity.JuegoId;
        }


        public ImagenesJuego ToEntyty()
        {

            return new ImagenesJuego() {
            Id=this.Id,
            Imagen= this.Imagen,
            ImageName= this.ImageName,
            IsActive= this.IsActive,
            JuegoId=this.JuegoId
            };
        }
        //public virtual JuegoViewModel Juego { get; set; }
    }
}