using Fiap.Web.Donation4.Data;
using Fiap.Web.Donation4.Models;
using Microsoft.Data.SqlClient;

namespace Fiap.Web.Donation4.Repository
{
    public class CategoriaRepository
    {

        private readonly DataContext _dataContext;
        public CategoriaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public IList<CategoriaModel> FindAll() {
            var categorias = _dataContext.Categorias.ToList();
            //return categorias == null ? new List<CategoriaModel>() : categorias;
            return _dataContext.Categorias.ToList() ?? new List<CategoriaModel>();
        }


        public CategoriaModel FindById(int id) {
            return _dataContext.Categorias.Find(id);
        }

        public int Insert(CategoriaModel categoriaModel) {
            _dataContext.Categorias.Add(categoriaModel);
            _dataContext.SaveChanges();

            return categoriaModel.CategoriaId;
        }

        public void Update(CategoriaModel categoriaModel) { 
            _dataContext.Categorias.Update(categoriaModel);
            _dataContext.SaveChanges();
        }

        public void Delete(int id) {

            /*
            var categoria = new CategoriaModel()
            {
                CategoriaId = id
            };
            */

            var categoria = FindById(id);
            _dataContext.Categorias.Remove(categoria);
            _dataContext.SaveChanges();

        }



        /*
public IList<CategoriaModel> FindAll()
        {
            var categorias = new List<CategoriaModel>();

            // Substitua pela sua string de conexão real
            string connectionString = "sua_string_de_conexao";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Nome FROM Categorias"; 

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var categoria = new CategoriaModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nome = reader["Nome"].ToString()
                            };

                            categorias.Add(categoria);
                        }
                    }
                }
            }

            return categorias;
        }

        */


    }
}
