﻿using DAL.Context;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class FeedBackRepos : BaseRepos<Feedback>
    {
        public FeedBackRepos(GSContext feedbackContext) : base(feedbackContext) { }
    }
}
