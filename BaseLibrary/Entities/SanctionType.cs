using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class SanctionType : BaseEntity
    {
        //Muchos a uno relacionado con sanciones
        public List<Sanction>? Sanctions { get; set; }
    }
}
