using Gamers.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gamers.Web.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            var clientes = GetClientes();
            
            return View(clientes);
        }

        public ActionResult Crear() 
        {
            return View();
        }

        [HttpGet]
        public ActionResult Editar(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            var cliente = GetClientes().FirstOrDefault(x=>x.Id==id.Value);
            if (cliente==null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }
        [HttpPost]
        public ActionResult Editar(ClienteViewModel cliente)
        {
            return RedirectToAction("Index");
        }

        private List<ClienteViewModel> GetClientes() 
        {

            var listaClientes = new List<ClienteViewModel>()
            {
                new ClienteViewModel(){
                Id=1,
                Nombre="Leonel",
                Apellido="Quiroga",
                Dni="3878913",
                Genero="M"
                }, new ClienteViewModel(){
                Id=2,
                Nombre="Ignacio",
                Apellido="Mendia",
                Dni="233234",
                Genero="M"
                }, new ClienteViewModel(){
                Id=3,
                Nombre="Alguno ",
                Apellido="Deporai",
                Dni="3878913www",
                Genero="M"
                }, new ClienteViewModel(){
                Id=4,
                Nombre="Gimena",
                Apellido="Rojas",
                Dni="3878913",
                Genero="F"
                }, new ClienteViewModel(){
                Id=5,
                Nombre="Susana",
                Apellido="Oria",
                Dni="3878913",
                Genero="F"
                }
            };

            return listaClientes;

        }
    }
}