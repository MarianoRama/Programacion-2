using LibreriaWebApp.Filters;
using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace TiendaWebApp.Controllers
{
    [Logueado]
    [ClienteFilter]
    public class ClienteController : Controller
    {
        private Sistema sistema = Sistema.Instancia;
        public IActionResult CargarSaldo(string mensaje, string successMessage)
        {
            ViewBag.Mensaje = mensaje;
            ViewBag.successMessage = successMessage;
            return View();
        }

        [HttpPost]
        public IActionResult CargarSaldo(int saldo)
        {
            try
            {
                Cliente elusuario = sistema.BuscarClientePorEmail(HttpContext.Session.GetString("email"));
                elusuario.CargarSaldo(saldo);
                ViewBag.successMessage = "Monto depositado exitosamente.";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "El monto a depositar debe de ser mayor a 0.";
                return View();
            }
        }
    }
}
