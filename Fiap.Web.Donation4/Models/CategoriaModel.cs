using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.Donation4.Models
{

    [Table("Categoria")]
    public class CategoriaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(100)]
        //[Column(name: "NM_CATEGORIA")]
        public string NomeCategoria { get; set; }


        [NotMapped]
        public string Token { get; set; }

    }
}
