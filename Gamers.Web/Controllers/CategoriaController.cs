using Gamers.DataAccess;
using Gamers.DataAccess.Models;
using Gamers.Web.Models;
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
            var listafinal = lista.Select(x => new CategoriaViewModel(x)).ToList();
            return View(listafinal);
        }

        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(CategoriaViewModel categoria)
        {
            if (!ModelState.IsValid)
            {
                //ModelState.AddModelError("", "Pone todo pelotudo");
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            try
            {                  
                _context.Categoria.Add(categoria.ToEntity());
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.Contains("IX_"))
                {
                    ModelState.AddModelError(string.Empty, "Categoria existente");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return View(categoria);
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Baja")]
        [ValidateAntiForgeryToken]
        public ActionResult Baja(int id)
        {           
            var Categoria=_context.Categoria.Find(id);
            if (Categoria==null)
            {
                return HttpNotFound();
            }
            try
            {
                _context.Categoria.Remove(Categoria);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.Contains("Reference"))
                {
                    ModelState.AddModelError(string.Empty,"La categoria tiene datos en otra tabla");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return View(Categoria);
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public ActionResult Baja(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var Categoria = _context.Categoria.Find(id);
            if (Categoria == null)
            {
                return HttpNotFound();
            }
            var categoriaVm = new CategoriaViewModel(Categoria);
            return View(categoriaVm);
        }

        [HttpGet]
        public ActionResult Modificar(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var Categoria =_context.Categoria.Find(id);
            if (Categoria==null)
            {
                return HttpNotFound();
            }
            var categoriaVm = new CategoriaViewModel(Categoria);
            return View(categoriaVm);
        }

        [HttpPost]
        public ActionResult Modificar(CategoriaViewModel categoria)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            try
            {
                var categoriaBD = _context.Categoria.Find(categoria.Id);
                if (categoriaBD == null)
                { 
                
                }
                // _context.Entry(categoria).State = System.Data.Entity.EntityState.Modified; TODO: ver esto
                _context.Entry(categoriaBD).CurrentValues.SetValues(categoria);
                _context.SaveChanges();
            }
            catch (Exception ex)
            { 
                if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.Contains("IX_"))
                {
                    ModelState.AddModelError(string.Empty, "Ya existe gil");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return View(categoria);
            }
            return RedirectToAction("Index");
        }
    }
}
