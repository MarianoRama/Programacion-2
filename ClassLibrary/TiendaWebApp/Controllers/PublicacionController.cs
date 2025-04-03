using LibreriaWebApp.Filters;
using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;

namespace TiendaWebApp.Controllers
{
    [Logueado]
    public class PublicacionController : Controller
    {
        private Sistema sistema = Sistema.Instancia;

        [ClienteFilter]
        public IActionResult Index(string nombre, string mensaje, string successMessage)
        {
            try
            {
                ViewBag.Mensaje = mensaje;
                ViewBag.successMessage = successMessage;
                if (sistema.Publicaciones.Count > 0)
                {
                    sistema.OrdendarPublicaciones();
                    return View(sistema.Publicaciones);
                }
                else
                {
                    ViewBag.Mensaje = "No hay publicaciones disponibles.";
                    return View(sistema.Publicaciones);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "No hay publicaciones disponibles.";
                return View(sistema.Publicaciones);
            }
        }

        [AdministradorFilter]
        public IActionResult IndexAdmin(string nombre, string mensaje, string successMessage)
        {
            try
            {
                ViewBag.Mensaje = mensaje;
                ViewBag.successMessage = successMessage;
                if (sistema.Publicaciones.Count > 0)
                {
                    sistema.OrdendarPublicaciones();
                    return View(sistema.Publicaciones);
                }
                else
                {
                    ViewBag.Mensaje = "No hay publicaciones disponibles.";
                    return View(sistema.Publicaciones);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "No hay publicaciones disponibles.";
                return View(sistema.Publicaciones);
            }
        }

        [ClienteFilter]
        public IActionResult Ofertar(int id)
        {
            try
            {
                Subasta subasta = sistema.BuscarSubastaPorId(id);
                Oferta oferta = new Oferta();
                oferta.Usuario = sistema.BuscarClientePorEmail(HttpContext.Session.GetString("email"));

                if (!subasta.Ofertas.Contains(oferta))
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", new { mensaje = "Ya ofertaste en esta subasta." });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { mensaje = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult Ofertar(int id, Oferta oferta)
        {
            try
            {
                Cliente elusuario = sistema.BuscarClientePorEmail(HttpContext.Session.GetString("email"));
                if (elusuario != null)
                {
                    oferta.Usuario = elusuario;
                }
                oferta.Fecha = DateTime.Now;
                Subasta subasta = sistema.BuscarSubastaPorId(id);
                subasta.Ofertar(oferta);
                return RedirectToAction("Index", new { successMessage = "Oferta realizada exitosamente." });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { mensaje = ex.Message });
            }
        }

        [ClienteFilter]
        public IActionResult Comprar(int id)
        {
            try
            {
                Venta venta = sistema.BuscarVentaPorId(id);
                Cliente elusuario = sistema.BuscarClientePorEmail(HttpContext.Session.GetString("email"));
                venta.ComprarVenta(elusuario);
                return RedirectToAction("Index", new { successMessage = "Compra realizada exitosamente." });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", new { mensaje = ex.Message });
            }
        }

        [AdministradorFilter]
        public IActionResult Finalizar(int id)
        {
            try
            {
                Subasta subasta = sistema.BuscarSubastaPorId(id);
                Administrador admin = sistema.BuscarAdministradorPorEmail(HttpContext.Session.GetString("email"));
                subasta.FinalizarPublicacion(admin);
                return RedirectToAction("IndexAdmin", new { successMessage = "Subasta finalizada exitosamente." });
            }
            catch (Exception ex)
            {
                return RedirectToAction("IndexAdmin", new { mensaje = ex.Message });
            }
        }
    }
}