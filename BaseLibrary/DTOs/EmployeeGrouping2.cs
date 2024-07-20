﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.DTOs
{
    public class EmployeeGrouping2
    {
        [Required]
        public string JobName { get; set; } = string.Empty;

        [Required, Range(1, 99999, ErrorMessage = "Debes selecionar una Rama ")]
        public int BranchId { get; set; }

        [Required, Range(1, 99999, ErrorMessage = "Debes selecionar una Ciudad ")]
        public int TownId { get; set; }
        

        [Required]
        public int? Burden { get; set; }

        [Required]
        public string? Other { get; set; }

        
    }
}
