using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSAppLogic.DTO
{
    public class FeedbackDTO : BaseModelDTO
    {
        public override string Name { get; set; }
        public string Content { get; set; }
        public int Stars { get; set; }
        public string GasStationName { get; set; }
        public string UserName { get; set; }
    }
}
