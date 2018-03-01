using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Models;

namespace ProductManager.Controllers
{
    public class UsuarioController : Controller
    {

        static List<Usuario> listaUsuario = new List<Usuario>
        {
            new Usuario{Id=1, Nome= "Guilherme", Cpf= "12345678910", Email= "guilherme@gmail.com"},
            new Usuario{Id=2, Nome= "Vitor", Cpf="43250427845", Email= "vitor@gmail.com"},
            new Usuario{Id=3, Nome= "Tiago", Cpf="9876543210", Email= "tiago@gmail.com"}
            };

        // GET: Usuario
        public ActionResult Index()
        {
            return View(listaUsuario);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            var usuario = listaUsuario.FirstOrDefault(d=> d.Id == id);
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario  usuario)
        {
            try
            {
                // TODO: Add insert logic here
                listaUsuario.Add(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var usuario = listaUsuario.FirstOrDefault(e => e.Id == id);
            if(usuario == null)
                {
                    return NotFound();
                }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id, Nome, Cpf, Email")] Usuario usuario)
        {
            try
            {
                // TODO: Add update logic here
                if (id != usuario.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    var usuarioTemp = listaUsuario.FirstOrDefault(e => e.Id == id);
                    if (usuarioTemp!= null)
                    {
                        usuarioTemp.Nome = usuario.Nome;
                        usuarioTemp.Cpf = usuario.Cpf;
                        usuarioTemp.Email = usuario.Email;
                    }
                    else
                    {
                        return NotFound();
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = listaUsuario.FirstOrDefault(y => y.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var usuario= listaUsuario.FirstOrDefault(y => y.Id == id);
                listaUsuario.Remove(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}