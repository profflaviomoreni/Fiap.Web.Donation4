using Fiap.Web.Donation4.Data;
using Fiap.Web.Donation4.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Donation4.Repository
{
    public class UsuarioRepository
    {
        private readonly DataContext _dataContext;

        public UsuarioRepository(DataContext context)
        {
            _dataContext = context;
        }


        public UsuarioModel Login(string email, string password)
        {
            var usuarioModel = _dataContext
                                   .Usuarios
                                   .Where(u => u.Senha == password && u.Email == email)
                                   .AsNoTracking()
                                   .FirstOrDefault();

            return usuarioModel;
        }

    }
}
