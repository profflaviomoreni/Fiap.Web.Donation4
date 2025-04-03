using Fiap.Web.Donation4.Data;
using Fiap.Web.Donation4.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Donation4.Repository
{
    public class ProdutoRepository
    {

        private readonly DataContext _dataContext;

        public ProdutoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public List<ProdutoModel> FindAll() { 
            
            return _dataContext.Produtos.AsNoTracking().ToList() ?? new List<ProdutoModel>();
        }

        public List<ProdutoModel> FindAllAvaliables()
        {
            return _dataContext.Produtos
                        .Where( 
                             p => p.Disponivel == true && 
                             p.DataExpiracao >= DateTime.UtcNow 
                        )
                        .AsNoTracking()
                        .ToList() ?? new List<ProdutoModel>();
        }


        public List<ProdutoModel> FindAllAvaliablesWithCategoriaAndUser()
        {
            return _dataContext.Produtos
                        .Where(
                             p => p.Disponivel == true &&
                             p.DataExpiracao >= DateTime.UtcNow
                        )
                        .Include(p => p.Categoria)
                        .Include(u => u.Usuario)
                        .AsNoTracking()
                        .ToList() ?? new List<ProdutoModel>();
        }


        public List<ProdutoModel> FindAllAvaliablesById(int? userId)
        {
            return _dataContext.Produtos
                        .Where(
                             p => p.Disponivel == true &&
                             p.DataExpiracao >= DateTime.UtcNow &&
                             p.UsuarioId == userId
                        )
                        .Include(p => p.Categoria)
                        .Include(u => u.Usuario)
                        .AsNoTracking()
                        .ToList() ?? new List<ProdutoModel>();
        }


        public List<ProdutoModel> FindAllAvaliablesForChanges(int? userId)
        {
            return _dataContext.Produtos
                        .Where(
                             p => p.Disponivel == true &&
                             p.DataExpiracao >= DateTime.UtcNow &&
                             p.UsuarioId != userId
                        )
                        .Include(p => p.Categoria)
                        .Include(u => u.Usuario)
                        .AsNoTracking()
                        .ToList() ?? new List<ProdutoModel>();
        }


        public ProdutoModel FindById(int id)
        {
            return _dataContext.Produtos
                        .Include( c => c.Categoria )
                        .Include( u => u.Usuario )
                        .AsNoTracking()
                        .SingleOrDefault( p=> p.ProdutoId == id );
        }


        public int Insert(ProdutoModel ProdutoModel)
        {
            _dataContext.Produtos.Add(ProdutoModel);
            _dataContext.SaveChanges();

            return ProdutoModel.ProdutoId;
        }


        public void Update(ProdutoModel ProdutoModel)
        {
            _dataContext.Produtos.Update(ProdutoModel);
            _dataContext.SaveChanges();
        }


        public void Delete(int id)
        {
            var Produto = new ProdutoModel()
            {
                ProdutoId = id
            };

            _dataContext.Produtos.Remove(Produto);
            _dataContext.SaveChanges();

        }

    }
}
