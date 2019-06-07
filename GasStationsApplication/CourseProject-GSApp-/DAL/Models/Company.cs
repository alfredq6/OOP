using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Company")]
    public class Company : BaseModel
    {
        [Key]
        public override string Name { get; set; }
        public string WebSiteLink { get; set; }
        public List<GasStation> ListGasStations { get; set; }
    }
}
