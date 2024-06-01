

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class GeneralDepartment : BaseEntity
    {
        //relationship: one To many
  
        public List<Employee>? Employees { get; set; }
    }
}
