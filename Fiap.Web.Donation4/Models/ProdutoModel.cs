namespace Fiap.Web.Donation4.Models
{
    public class ProdutoModel
    {

        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        public bool Disponivel { get; set; }

        //Categoria do Produto
        public int CategoriaId { get; set; }

        public string Descricao { get; set; }

        public string SugestaoTroca { get; set; }

        public double Valor { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataExpiracao { get; set; }


        // Usuario dono do produto
        public int UsuarioId { get; set; }

    }
}
