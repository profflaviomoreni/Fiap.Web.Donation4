using Fiap.Web.Donation4.Data;
using Fiap.Web.Donation4.Models;
using Fiap.Web.Donation4.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.Donation4.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly int UserId = 1;

        private readonly DataContext _dataContext;
        private readonly CategoriaRepository _categoriaRepository;
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoController(DataContext dataContext)
        {
            _dataContext = dataContext;
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

            produtoModel.UsuarioId = UserId;

            if ( ModelState.IsValid ) {
                _dataContext.Produtos.Add(produtoModel);
                _dataContext.SaveChanges();

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

            return View(produto);
        }


        [HttpPost]
        public IActionResult Editar(ProdutoModel produtoModel)
        {

            produtoModel.UsuarioId = UserId;

            if ( string.IsNullOrEmpty(produtoModel.Nome) ) {

                var mensagem = "O campo Nome é requerido, favor preencher";

                ViewBag.ErrorMessage = mensagem;

                return View(produtoModel);

            } else
            {
                var mensagem = $"O produto {produtoModel.Nome} foi alterado com sucesso";

                TempData["SuccessMessage"] = mensagem;

                

                // UPDATE produto SET ... WHERE produtoId = {produtomodel.ProdutoId}
                return RedirectToAction(nameof(Index));
            }

        }


        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            var produto = _produtoRepository.FindById(id);
            return View(produto);
        }



        private List<ProdutoModel> ListarProdutosMock()
        {
            // SELECT * FROM produtos;

            var produtos = new List<ProdutoModel>{
                new ProdutoModel()
                {
                    ProdutoId = 1,
                    Nome = "Iphone 11",
                    CategoriaId = 1,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 2,
                    Nome = "Iphone 12",
                    CategoriaId = 2,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 3,
                    Nome = "Iphone 13",
                    CategoriaId = 1,
                    Disponivel = true,
                    DataExpiracao = DateTime.Now,
                },
                new ProdutoModel()
                {
                    ProdutoId = 4,
                    Nome = "Iphone 14",
                    CategoriaId = 1,
                    Disponivel = false,
                    DataExpiracao = DateTime.Now,
                },
            };

            return produtos;
        }


    }
}
