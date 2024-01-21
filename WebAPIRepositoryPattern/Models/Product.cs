using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPIRepositoryPattern.Repository;

namespace WebAPIRepositoryPattern.Models
{
    public class Product: IEntityBase
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduct { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string NameProduct { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
