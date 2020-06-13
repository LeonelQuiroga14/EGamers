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
       
        public string Descripcion { get; set; }

        public int? EdadMinima { get; set; }

    }
}
