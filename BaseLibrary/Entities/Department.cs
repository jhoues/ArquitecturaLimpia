using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    //many to one relationship with General departament
    public class Department : BaseEntity
    {
        //muchos a una realcionado con General Departaments
        public GeneralDepartment? GeneralDepartment { get; set; }
        
        public int GeneralDepartmentId { get; set; }
        //uno a muchos relacionado con Branch
        [JsonIgnore]
        public List<Branch>? Branches { get; set; }
    }
}
