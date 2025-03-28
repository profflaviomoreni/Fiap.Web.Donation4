using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.Donation4.Models
{

    [Table("Produto")]
    public class ProdutoModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(50, ErrorMessage = "O tamanho máximo para o campo nome é de 50 caracteres")]
        [Display(Name = "Nome do produto")]
        public string Nome { get; set; }

        public bool Disponivel { get; set; }

        public string Descricao { get; set; }

        [Required]
        [StringLength(200)]
        public string SugestaoTroca { get; set; }

        [Required]
        [Range(minimum:10, maximum:15000000, ErrorMessage = "O valor mínimo é de 10 reais")]
        public double Valor { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public DateTime DataExpiracao { get; set; }


        //Categoria do Produto
        [Required]
        public int CategoriaId { get; set; }

        // Navigation Property
        [ForeignKey(nameof(CategoriaId))]
        public CategoriaModel? Categoria { get; set; }


        // Usuario dono do produto
        [Required]
        public int UsuarioId { get; set; }

        [ForeignKey(nameof(UsuarioId))]
        public UsuarioModel? Usuario { get; set; }

    }
}
