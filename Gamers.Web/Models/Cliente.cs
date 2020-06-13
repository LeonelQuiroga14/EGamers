using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamers.Web.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Genero { get; set; }
    }
}