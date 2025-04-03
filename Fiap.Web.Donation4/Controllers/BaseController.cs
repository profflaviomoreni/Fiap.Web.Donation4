using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation4.Controllers
{
    public class BaseController : Controller
    {
        public readonly int? UserId = 0;

        public readonly string? UsuarioNome = string.Empty;

        public readonly bool Autenticado = false;

        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
            if ( httpContextAccessor.HttpContext != null && httpContextAccessor.HttpContext.Session != null )
            {
                UserId = httpContextAccessor.HttpContext.Session.GetInt32("UserId");
                UsuarioNome = httpContextAccessor.HttpContext.Session.GetString("UsuarioNome");

                if ( UserId != null && UserId != 0)
                {
                    Autenticado = true;
                }

            }            
        }

    }
}
