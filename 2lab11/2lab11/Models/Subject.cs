using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab11.Models
{
    public class Subject
    {
        [Key]
        public string Name { get; set; }
        public int HoursNumber { get; set; }
        public string LectorName { get; set; }
        public int StudentsNumber { get; set; }
    }
}
