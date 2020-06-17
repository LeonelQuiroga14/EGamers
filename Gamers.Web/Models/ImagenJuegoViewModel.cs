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


        //public virtual JuegoViewModel Juego { get; set; }
    }
}