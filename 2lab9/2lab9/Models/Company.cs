using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab9.Models
{
    public class Company
    {
        [Key]
        public string Name { get; set; }
        public string Adress { get; set; }
        public decimal Cost { get; set; }
    }
}
