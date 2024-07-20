using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class OtherBaseEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeEmail { get; set; }
    }
}
