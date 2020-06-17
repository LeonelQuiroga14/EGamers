using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamers.Web.Models
{
    public class ImagenViewModel
    {
        public ImagenViewModel()
        {
            Image = new List<HttpPostedFileBase>();
        }
     
      public List<HttpPostedFileBase> Image { get; set; }
      public int JuegoId { get; set; }
    }
}