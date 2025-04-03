using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaWebApp.Filters
{
	public class AdministradorFilter : ActionFilterAttribute
	{
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			string rol = context.HttpContext.Session.GetString("rol");
			if (string.IsNullOrEmpty(rol) || rol != "Administrador")
			{
				context.Result = new RedirectToActionResult("Index", "Tienda", new { mensaje = "Acceso restringido." });
			}
			base.OnActionExecuted(context);
		}
	}
}
