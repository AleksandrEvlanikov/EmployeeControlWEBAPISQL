using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeControlWebAPI.Model
{
    public class Employees
    {
        public int EmployeesId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Position { get; set; }
        public List<Shifts> Shifts { get; set; }
    }
}
