﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class VacationType:BaseEntity
    {
        //muchos a uno relacionado con vacaciones
        public List<Vacation>? Vacations { get; set; }
    }
}
