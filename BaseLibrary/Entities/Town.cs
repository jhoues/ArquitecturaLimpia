using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class Town : BaseEntity
    {
        //Relacion uno a muchos con Empleados
        [JsonIgnore]
        public List<Employee>? Employees { get; set; }
        //Muchos a uno relacionado con City
        public City? City { get; set; }
        public int CityId { get; set; }
    }
}
