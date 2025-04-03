using Fiap.Web.Donation4.Data;
using Fiap.Web.Donation4.Models;
using Fiap.Web.Donation4.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fiap.Web.Donation4.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ProdutoRepository _produtoRepository;

        public HomeController(  ILogger<HomeController> logger, 
                                DataContext dataContext, 
                                IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _logger = logger;
            _produtoRepository = new ProdutoRepository(dataContext);
        }

        public IActionResult Index()
        {
            var produtos = new List<ProdutoModel>();

            if (Autenticado) { 
                produtos = _produtoRepository.FindAllAvaliablesForChanges(UserId);
            } else
            {
                produtos = _produtoRepository.FindAllAvaliablesWithCategoriaAndUser();
            }

            return View(produtos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
