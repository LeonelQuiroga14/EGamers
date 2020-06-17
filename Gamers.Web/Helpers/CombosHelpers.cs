using Gamers.DataAccess;
using Gamers.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gamers.Web.Helpers
{
    public class CombosHelpers
    {
        //TODO:buscar inject
        public static EGamersContext _db => new EGamersContext();
        public static List<Categoria> GetCategorias()
        {
            var Lista = _db.Categoria.ToList();

            var categoria = new Categoria {Id = 0, Descripcion = "[Seleccione una categoria]" };
            Lista.Add(categoria);
            Lista = Lista.OrderBy(o => o.Descripcion).ToList();
            return Lista;
        }


        public static List<Juego> GetJuegos()
        {
            var Lista = _db.Juego.ToList();

            var juego = new Juego { Id = 0, Nombre = "[Seleccione un juego]" };
            Lista.Add(juego);
            Lista = Lista.OrderBy(o => o.Nombre).ToList();
            return Lista;
        }
    }
}