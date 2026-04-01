namespace Models
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        //===== Navigation =====
        public ICollection<Employee> Employees { get; set; }=new List<Employee>();
    }
}
