using LibreriaWebApp.Filters;
using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace TiendaWebApp.Controllers
{
    public class TiendaController : Controller
    {
        private Sistema sistema = Sistema.Instancia;

        [Logueado]
        public IActionResult Index()
        {
            return View();
        }

        // LOGIN
        public IActionResult Login(string successMessage)
        {
            ViewBag.successMessage = successMessage;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("email")))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            try
            {
                Usuario logueado = sistema.AutenticarUsuario(email, password);
                HttpContext.Session.SetString("nombre", logueado.Nombre);
                HttpContext.Session.SetString("email", email);
                HttpContext.Session.SetString("rol", logueado.GetType().Name);
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                ViewBag.errorMessage = ex.Message;
                HttpContext.Session.SetString("email", "");
                return View();
            }
        }

        // REGISTRO
        public IActionResult CrearCliente(string mensaje)
        {
            ViewBag.errorMessage = mensaje;
            return View();
        }
        [HttpPost]
        public IActionResult CrearCliente(Cliente cliente)
        {
            try
            {
                cliente.Validar();
                sistema.AgregarUsuario(cliente);
                return RedirectToAction("Login", new { successMessage = "Usuario " + cliente.Nombre + " registrado corractamente." });
            }
            catch (Exception ex)
            {
                return RedirectToAction("CrearCliente", new { mensaje = ex.Message });
            }
        }
        [Logueado]
        public IActionResult logout(string mensaje)
        {
            try
            {
                HttpContext.Session.SetString("email", "");
                HttpContext.Session.SetString("nombre", "");
                HttpContext.Session.SetString("rol", "");
                ViewBag.Error = mensaje;
                return RedirectToAction("Login", new { successMessage = "Se cerró sesión con exito." });
            }
            catch
            {
                return View();
            }
        }
    }
}