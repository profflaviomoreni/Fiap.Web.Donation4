using Fiap.Web.Donation4.Data;
using Fiap.Web.Donation4.Models;
using Fiap.Web.Donation4.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.Donation4.Controllers
{
    public class TrocaController : BaseController
    {

        public readonly ProdutoRepository _produtoRepository;

        public readonly TrocaRepository _trocaRepository;
        public  IHttpContextAccessor _httpContextAccessor { get; set; }


        public TrocaController(DataContext dataContext, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _produtoRepository = new ProdutoRepository(dataContext);
            _trocaRepository = new TrocaRepository(dataContext);
            _httpContextAccessor = httpContextAccessor;

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
            try
            {
                var produtoEscolhido = _produtoRepository.FindById(trocaModel.ProdutoIdEscolhido);
                var produtoMeu = _produtoRepository.FindById(trocaModel.ProdutoIdMeu); // Produto que eu estou dando na troca

                if (produtoEscolhido.Disponivel == false)
                {
                    throw new Exception("Produto escolhido foi utilizando em uma outra troca");
                }

                if (produtoMeu.Disponivel == false)
                {
                    throw new Exception("O seu produto foi utilizando em uma outra troca");
                }

                //if ( (produtoMeu.Valor / produtoEscolhido.Valor) < 0.9 )
                //{
                //    throw new Exception("Valor incompatível para possível troca");
                //}

                produtoEscolhido.Disponivel = false;
                _produtoRepository.Update(produtoEscolhido);

                produtoMeu.Disponivel = false;
                _produtoRepository.Update(produtoMeu);

                trocaModel.TrocaStatus = TrocaStatus.Iniciado;
                _trocaRepository.Insert(trocaModel);

                TempData["Sucesso"] = "Troca efetuada com sucesso";

            } catch (Exception ex)
            {
                TempData["Erro"] = $"Problema na troca: {ex.Message}";
            }

            return RedirectToAction(nameof(Index),"Home");
        }


    }
}
