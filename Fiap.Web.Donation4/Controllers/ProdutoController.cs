using Fiap.Web.Donation4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation4.Controllers
{
    public class ProdutoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // listaProdutos
            var produtos = ListarProdutosMock();

            //ViewBag.Produtos = produtos;
            
            return View(produtos);
        }


        [HttpGet]
        public IActionResult Editar(int id)
        {
            // SELECT * FROM produto WHERE ProdutoId = {id}

            var produto = ListarProdutosMock().Where( p=> p.ProdutoId == id).FirstOrDefault();

            return View(produto);
        }


        [HttpPost]
        public IActionResult Editar(ProdutoModel produtoModel)
        {

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
            // SELECT * FROM produto WHERE ProdutoId = {id}

            var produto = ListarProdutosMock().Where(p => p.ProdutoId == id).FirstOrDefault();

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
