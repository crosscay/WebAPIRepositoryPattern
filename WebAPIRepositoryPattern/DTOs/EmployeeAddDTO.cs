using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIRepositoryPattern.DTOs
{
    public class EmployeeAddDTO
    {
        [Column("NAME")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        //[StringLength(maximumLength: 100, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        public string Name { get; set; } = string.Empty;

        [Column("DESIGNATION")]
        public string Designation { get; set; } = string.Empty;

        [Column("DEPARTAMENT")]
        public string Department { get; set; } = string.Empty;

        [Column("DATE")]
        public string Date { get; set; } = string.Empty;
    }
}
