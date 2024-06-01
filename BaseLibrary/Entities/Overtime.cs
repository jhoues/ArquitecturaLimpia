﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class Overtime : OtherBaseEntity
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public int NumberOfDays => (EndDate - StartDate).Days;

        // Many to one relationship with Vacation Type
        //muchos a uno relacionado con TipoDeVacaciones
        public OvertimeType? OvertimeType { get; set; }
        [Required]
        public int OvertimeTypeId { get; set; }
    }
}
