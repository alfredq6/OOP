using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab9.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Wage { get; set; }
        public string Post { get; set; }
        public string CompanyName { get; set; }
        [ForeignKey("CompanyName")]
        public Company Company { get; set; }
    }
}
