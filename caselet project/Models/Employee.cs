namespace Apidbfirstassign.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }

        public int ProjectId { get; set; } // Foreign Key

        public Project? Project { get; set; } // Nullable, so not required in POST
    }
}
