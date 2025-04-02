using Fiap.Web.Donation4.Data;
using Fiap.Web.Donation4.Models;
using Fiap.Web.Donation4.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.Donation4.Controllers
{
    public class TrocaController : Controller
    {
        private readonly int UserId = 1;

        public readonly ProdutoRepository _produtoRepository;

        public readonly TrocaRepository _trocaRepository;

        public TrocaController(DataContext dataContext)
        {
            _produtoRepository = new ProdutoRepository(dataContext);
            _trocaRepository = new TrocaRepository(dataContext);
        }


        [HttpGet]
        public IActionResult Index(int id)
        {
            var produtoEscolhido = _produtoRepository.FindById(id);

            var trocaModel = new TrocaModel();
            trocaModel.ProdutoEscolhido = produtoEscolhido;

            var meusProdutos = _produtoRepository.FindAllAvaliablesById(UserId);
            ViewBag.MeusProdutos = new SelectList(meusProdutos, "ProdutoId", "Nome");

            return View(trocaModel);
        }

        [HttpPost]
        public IActionResult Index(TrocaModel trocaModel)
        {
            return View();
        }


    }
}
