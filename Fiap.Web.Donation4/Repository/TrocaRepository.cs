using Fiap.Web.Donation4.Data;
using Fiap.Web.Donation4.Models;

namespace Fiap.Web.Donation4.Repository
{
    public class TrocaRepository
    {

        private readonly DataContext _context;

        public TrocaRepository(DataContext dataContext)
        {
            _context = dataContext;
        }


        public Guid Insert(TrocaModel model)
        {
            _context.Trocas.Add(model);
            _context.SaveChanges();

            return model.TrocaId;
        }

    }
}
