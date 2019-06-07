using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class GasStation : BaseModel
    {
        public double distanceLength;
        [Key]
        public override string Name { get; set; }
        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int AverageStars { get; set; }
        public int FeedbacksNumber { get; set; }
        public decimal? AI92_Price { get; set; }
        public decimal? AI95_Price { get; set; }
        public decimal? AI98_Price { get; set; }
        public decimal? DT_Price { get; set; }
        public decimal? GAS_Price { get; set; }
        [ForeignKey("CompanyName")]
        public Company Company { get; set; }
        public List<Feedback> ListFeedbacks { get; set; }
    }
}
