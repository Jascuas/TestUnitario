using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUnitario.Models;

namespace TestUnitario.Controllers
{
    public class UsuariosController : Controller
    {
        public List<Usuario> GetUsuarios()
        {
            List<Usuario> Usuarios = new List<Usuario> {
                    new Usuario {IdUser = 1,
                        Nombre = "Alan",
                        Apellidos = "Walker Land",
                        Contraseña = "1234",
                        FechaRegistro = DateTime.Parse(DateTime.Now.ToLongDateString())
                },
                    new Usuario {
                        IdUser = 2,
                        Nombre = "Lucia",
                        Apellidos = "Clare Huhg",
                        Contraseña = "1234",
                        FechaRegistro = DateTime.Parse(DateTime.Now.ToLongDateString())
                },
                    new Usuario {
                        IdUser = 3,
                        Nombre = "Mario",
                        Apellidos = "Its Me",
                        Contraseña = "1234",
                        FechaRegistro = DateTime.Parse(DateTime.Now.ToLongDateString())
                },
                    new Usuario {
                        IdUser = 4,
                        Nombre = "Guillermin",
                        Apellidos = "Peter Jordanson",
                        Contraseña = "1234",
                        FechaRegistro = DateTime.Parse(DateTime.Now.ToLongDateString())
                }
            };
            return Usuarios;
        }
        public ActionResult ModeloUsuarios()
        {
            List<Usuario> Usuarios = GetUsuarios();
            return View(Usuarios);
        }
        public ActionResult ListaUsuarios()
        {
            List<Usuario> Usuarios = GetUsuarios();
            ViewBag.Usuarios = Usuarios;
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String nombre, String pass)
        {
            List<Usuario> Usuarios = GetUsuarios();
            if (nombre != null && pass != null)
            {
                foreach (Usuario user in Usuarios)
                {
                    if (user.Nombre == nombre && user.Contraseña == pass) return RedirectToAction("ModeloUsuarios", "Usuarios");
                }
            }
            ViewBag.Mensaje = "Datos no encontrados";
            return RedirectToAction("Login", "Usuarios");
        }

    }
}