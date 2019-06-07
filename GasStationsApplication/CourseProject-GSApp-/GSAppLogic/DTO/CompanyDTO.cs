using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSAppLogic.DTO
{
    public class CompanyDTO : BaseModelDTO
    {
        public override string Name { get; set; }
        public string WebSiteLink { get; set; }
    }
}
