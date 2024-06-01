using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class Country : BaseEntity
    {
        //uno a muchos relacionado con ciudades
        public List<City>? Cities { get; set; }
    }
}
