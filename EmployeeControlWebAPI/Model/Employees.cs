using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeControlWebAPI.Model
{
    public class Employees
    {
        [Required]
        public int EmployeesId { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Position { get; set; }
        public List<Shifts> Shifts { get; set; }
    }
}
