using Fiap.Web.Donation4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation4.Controllers
{
    public class ContatoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            Console.WriteLine("Contato -- Index");

            //"SELECT nomeMensagem FROM TBMENSAGEM WHERE ..."

            //return RedirectToAction("Index","Home");
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContatoModel contatoModel)
        {
            // INSERT INTO TBCONTATO VALUES (contatoModel.Nome, contatoModel.Sobrenome ...

            Console.WriteLine("Contato -- Cadastrar");

            return View();
        }

        [HttpGet]
        public IActionResult Help()
        {
            Console.WriteLine("Contato -- Help");

            var mensagem = "Carregada do banco de dados";
            TempData["msg"] = mensagem;


            return RedirectToAction(nameof(Index));
        }

    }
}
