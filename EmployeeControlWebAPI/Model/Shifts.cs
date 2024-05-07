namespace EmployeeControlWebAPI.Model
{
    public class Shifts
    {
        public int ShiftsId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int QuantityHoursWorked { get; set; }
        public int EmployeesId { get; set; }
    }
}
