using Gamers.DataAccess;
using Gamers.DataAccess.Models;
using Gamers.Web.Models;
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
        public static List<CategoriaViewModel> GetCategorias()
        {
            var Lista = _db.Categoria.ToList().Select(x=> new CategoriaViewModel(x)).ToList();

            var categoria = new CategoriaViewModel {Id = 0, Descripcion = "[Seleccione una categoria]" };
            Lista.Add(categoria);
            Lista = Lista.OrderBy(o => o.Descripcion).ToList();
            return Lista;
        }


        public static List<JuegoViewModel> GetJuegos()
        {
            var Lista = _db.Juego.ToList().Select(x=> new JuegoViewModel(x)).ToList();

            var juego = new JuegoViewModel{ Id = 0, Nombre = "[Seleccione un juego]" };
            Lista.Add(juego);
            Lista = Lista.OrderBy(o => o.Nombre).ToList();
            return Lista;
        }
    }
}