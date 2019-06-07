﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class FuelType : BaseModel
    {
        [Key]
        public override string Name { get; set; }
        public string MapLink { get; set; }
    }
}
