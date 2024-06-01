namespace BaseLibrary.Entities
{
    public class Branch : BaseEntity
    {
        // muchos a uno relacionado con Departamneto 
        public Department? Department { get; set; }
        public int DepartmentId { get; set; }
        //Relacionado uno a muchos con Employee
        public List<Employee>? Employees { get; set; }
    }
}
