using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPIRepositoryPattern.Repository;

namespace WebAPIRepositoryPattern.Models
{
    public class Employee: IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }

        [Required]
        public string? EmpName { get; set; }

        public string? Designation { get; set; }

        public string? Department { get; set; }

        public string? JoinDate { get; set; }
    }
}
