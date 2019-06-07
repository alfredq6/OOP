using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSAppLogic.DTO
{
    public class GasStationDTO : BaseModelDTO
    {
        public double distanceLength;
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
    }
}
