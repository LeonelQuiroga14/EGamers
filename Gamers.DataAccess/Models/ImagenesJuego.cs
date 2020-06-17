using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamers.DataAccess.Models
{
    public class ImagenesJuego
    {
        public int Id { get; set; }
        public byte[] Imagen { get; set; }
        public string ImageName { get; set; }
        public bool IsActive { get; set; }
        public int JuegoId { get; set; }

                     
        public virtual Juego Juego { get; set; }

    }
}
