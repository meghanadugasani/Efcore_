namespace Apidbfirstassign.Models
{
    public partial class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public decimal Budget { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }

}
