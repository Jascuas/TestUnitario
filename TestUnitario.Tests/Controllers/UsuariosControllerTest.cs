using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestUnitario.Controllers;
using TestUnitario.Models;

namespace TestUnitario.Tests.Controllers
{
    [TestClass]
    public class UsuariosControllerTest
    {
        [TestMethod]
        public void Testing_Model()
        {
            UsuariosController controller = new UsuariosController();
            var result = controller.ModeloUsuarios() as ViewResult;
            var mordelo = result.Model;
            Assert.IsNotNull(mordelo);
        }
        [TestMethod]
        public void Testing_ViewBag()
        {
            UsuariosController controller = new UsuariosController();
            var result = controller.ListaUsuarios() as ViewResult;
            List<Usuario> usuarios = controller.GetUsuarios();
            List<Usuario> us = result.ViewBag.Usuarios;
            Assert.AreEqual(usuarios[0].Nombre, us[0].Nombre);
        }
        [TestMethod]
        public void Testing_Redirect_With_An_Existing_User()
        {
            UsuariosController controller = new UsuariosController();
            RedirectToRouteResult result = controller.Login(nombre: "Alan", pass: "1234") as RedirectToRouteResult;
            Assert.AreEqual("ModeloUsuarios", result.RouteValues["action"]);
            Assert.AreEqual("Usuarios", result.RouteValues["controller"]);
        }
        [TestMethod]
        public void Testing_Redirect_With_An_User_That_Dont_Exist()
        {
            UsuariosController controller = new UsuariosController();
            RedirectToRouteResult result = controller.Login(nombre:"Javier", pass:"1234") as RedirectToRouteResult;
            Assert.AreEqual("Login", result.RouteValues["action"]);
            Assert.AreEqual("Usuarios", result.RouteValues["controller"]);
        }
    }
}
