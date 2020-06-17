using Gamers.DataAccess;
using Gamers.DataAccess.Models;
using Gamers.Web.Helpers;
using Gamers.Web.Models;
using Gamers.Web.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Gamers.Web.Controllers
{
    public class JuegoController : Controller
    {
        public readonly EGamersContext _context;
        public JuegoController()
        {
            _context = new EGamersContext();
        }

        // GET: Juego
        public ActionResult Index()
        {
            //Include() eagerLoadin en EF por si queres googlear, lo que hace es cuando busca los juegos automaticamente te trae la relacion de categoria 
            //en categoria pasa al revez te trae toda la lista de juegos
            var lista = _context.Juego.Include(x=>x.Categoria).ToList();
            return View(lista);
        }


        public ActionResult Alta()
        {

            //List<TableViewModel> Lista =
            //    (from c in _context.Categoria
            //     select new TableViewModel
            //     {
            //         Id = c.Id,
            //         Nombre = c.Descripcion
            //     }).ToList();

            //List<SelectListItem> item = Lista.ConvertAll(t =>
            //{
            //    return new SelectListItem()
            //    {
            //        Text = t.Nombre.ToString(),
            //        Value = t.Id.ToString(),
            //        Selected = false
            //    };
            //});
            ViewBag.Categorias = new SelectList(CombosHelpers.GetCategorias(),"Id", "Descripcion");
            

            return View();
        }
           
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alta(Juego juego)
        {
            if (!ModelState.IsValid)
            {

                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            try
            {
                _context.Juego.Add(juego);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.Contains("IX_"))
                {
                    ModelState.AddModelError(string.Empty, "Juego existente");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                return View(juego);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Baja(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var Juego = _context.Juego.Find(id);
            if (Juego == null)
            {
                return HttpNotFound();
            }
            return View(Juego);
        }

        [HttpPost]
        public ActionResult Baja(int id)
        {
            var Juego = _context.Juego.Find(id);
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            try
            {
                _context.Juego.Remove(Juego);                
            }
            catch (Exception)
            {
                return View(Juego);
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Modificacion(int? id)
        {
            List<TableViewModel> Lista =
                (from c in _context.Categoria
                 select new TableViewModel
                 {
                     Id = c.Id,
                     Nombre = c.Descripcion
                 }).ToList();

            List<SelectListItem> item = Lista.ConvertAll(t =>
            {
                return new SelectListItem()
                {
                    Text = t.Nombre.ToString(),
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.item = item;

            if (id==null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var Juego = _context.Juego.Find(id);
            if (Juego == null)
            {
                return HttpNotFound("No se encontró el juego a modificar");
            }
            return View(Juego);
        }

        [HttpPost]
        public ActionResult Modificacion(Juego juego)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            try
            {
                _context.Entry(juego).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception )
            {               
                return View(juego);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UploadImages()
        {
            var juegos = new SelectList(CombosHelpers.GetJuegos(), "Id", "Nombre");
            ViewBag.JuegoId = juegos;
            return View();
        }

        //Imagen TODO: levantar las imagenes 
        [HttpPost]
        public ActionResult UploadImages(ImagenViewModel uploadImages)
        {
            if (uploadImages.Image.Count() ==0)
            {
                return RedirectToAction("BrowseImages");
            }

            foreach (var image in uploadImages.Image)
            {
                if (image != null)
                {
                    if (image.ContentLength > 0)
                    {
                        byte[] imageData = null;
                        using (var binaryReader = new BinaryReader(image.InputStream))
                        {
                            imageData = binaryReader.ReadBytes(image.ContentLength);
                        }
                        var headerImage = new ImagenesJuego
                        {
                            Imagen = imageData,
                            JuegoId = uploadImages.JuegoId,
                            ImageName = image.FileName,
                            IsActive = true
                        };
                        try
                        {
                            _context.ImagenesJuegos.Add(headerImage);
                            _context.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                        
                       
                    }
                }
                else {
                    return RedirectToAction("UploadImages");
                }
            }
            return RedirectToAction("Index");
        }

    }
}



        



    