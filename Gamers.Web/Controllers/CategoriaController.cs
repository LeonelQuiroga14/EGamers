using Gamers.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gamers.Web.Controllers
{
    public class CategoriaController : Controller
    {
        public readonly EGamersContext _context;
        public CategoriaController()
        {
            _context = new EGamersContext();
        }
        // GET: Categoria
        public ActionResult Index()
        {
            var lista = _context.Categoria.ToList();
            return View(lista);
        }


    }
}