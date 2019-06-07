using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Feedback : BaseModel
    {
        [Key]
        public override string Name { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int Stars { get; set; }
        public string GasStationName { get; set; }
        public string UserName { get; set; }
        [ForeignKey("GasStationName")]
        public GasStation GasStation { get; set; }
        [ForeignKey("UserName")]
        public User User { get; set; }
    }
}
