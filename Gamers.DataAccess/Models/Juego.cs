using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamers.DataAccess.Models
{
    public class Juego
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
        public Categoria categoria { get; set; }
    }
}
