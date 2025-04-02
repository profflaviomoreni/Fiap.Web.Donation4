using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.Donation4.Models
{

    public enum TrocaStatus
    {
        Iniciado = 1,
        Analisado = 2,
        Finalizado = 3,
        Revertido = 4
    }

    [Table("Troca")]
    public class TrocaModel
    {
        [Key]
        public Guid TrocaId { get; set; } = Guid.NewGuid();

        public TrocaStatus TrocaStatus { get; set; }

        public DateTime? DataCriacao { get; set;} = DateTime.UtcNow;


        // Meu Produto
        public int ProdutoIdMeu { get; set; }

        //Navigation Property
        [ForeignKey(nameof(ProdutoIdMeu))]
        public ProdutoModel ProdutoMeu { get; set; }


        // Produto Escolhido
        public int ProdutoIdEscolhido { get; set;}

        //Navigation Property
        [ForeignKey(nameof(ProdutoIdEscolhido))]
        public ProdutoModel ProdutoEscolhido { get; set; }

    }
}
