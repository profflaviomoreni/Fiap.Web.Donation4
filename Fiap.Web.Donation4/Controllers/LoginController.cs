using Fiap.Web.Donation4.Data;
using Fiap.Web.Donation4.Models;
using Fiap.Web.Donation4.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation4.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsuarioRepository _usuarioRepository;

        public LoginController(DataContext dataContext)
        {
            _usuarioRepository = new UsuarioRepository(dataContext);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(UsuarioModel usuarioModel)
        {
            usuarioModel = _usuarioRepository.Login(usuarioModel.Email, usuarioModel.Senha);

            if (usuarioModel != null)
            {
                HttpContext.Session.SetInt32("UserId", usuarioModel.UsuarioId);
                HttpContext.Session.SetString("UsuarioNome", usuarioModel.Nome);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mensagem = "Usuário ou senha inválida";
                return View(usuarioModel);
            }

        }


        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
