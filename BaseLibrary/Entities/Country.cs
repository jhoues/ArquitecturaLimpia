﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class Country : BaseEntity
    {
        //uno a muchos relacionado con ciudades
        [JsonIgnore]
        public List<City>? Cities { get; set; }
    }
}
