﻿using DAL.Context;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CompanyRepos : BaseRepos<Company>
    {
        public CompanyRepos(GSContext companyContext) : base(companyContext) { }
    }
}
