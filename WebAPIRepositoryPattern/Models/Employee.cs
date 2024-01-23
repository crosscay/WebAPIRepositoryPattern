using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPIRepositoryPattern.Repository;

namespace WebAPIRepositoryPattern.Models
{
    public class Employee: IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string EmpName { get; set; } = string.Empty;

        public string Designation { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public string JoinDate { get; set; } = string.Empty;
    }
}
