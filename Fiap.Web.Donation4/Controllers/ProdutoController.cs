using Fiap.Web.Donation4.Data;
using Fiap.Web.Donation4.Models;
using Fiap.Web.Donation4.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.Donation4.Controllers
{
    public class ProdutoController : BaseController
    {

        private readonly CategoriaRepository _categoriaRepository;
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoController(DataContext dataContext, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _categoriaRepository = new CategoriaRepository(dataContext);
            _produtoRepository = new ProdutoRepository(dataContext);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var produtos = _produtoRepository.FindAllAvaliables();
            return View(produtos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadViewBagCategorias();

            return View(new ProdutoModel());
        }

        [HttpPost]
        public IActionResult Create(ProdutoModel produtoModel)
        {

            produtoModel.UsuarioId = (int)UserId;

            if ( ModelState.IsValid ) {
                _produtoRepository.Insert(produtoModel);

                var mensagem = $"O produto {produtoModel.Nome} foi inserido com sucesso";
                TempData["SuccessMessage"] = mensagem;
                return RedirectToAction(nameof(Index));
            } else
            {
                LoadViewBagCategorias();

                return View(new ProdutoModel());
            }

        }

        private void LoadViewBagCategorias()
        {
            var categorias = _categoriaRepository.FindAll();
            var selectCategorias = new SelectList(categorias, "CategoriaId", "NomeCategoria");
            ViewBag.Categorias = selectCategorias;
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var produto = _produtoRepository.FindById(id);
            LoadViewBagCategorias();
            return View(produto);
        }


        [HttpPost]
        public IActionResult Editar(ProdutoModel produtoModel)
        {

            if (ModelState.IsValid)
            {
                produtoModel.UsuarioId = (int) UserId;
                _produtoRepository.Update(produtoModel);

                TempData["MensagemSucesso"] = $"Produto {produtoModel.Nome} alterado com sucesso";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                LoadViewBagCategorias();
                ViewBag.MensagemErro = "Preencha todos os dados corretamente";
                return View(produtoModel);
            }

        }


        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            var produto = _produtoRepository.FindById(id);
            return View(produto);
        }

    }
}
