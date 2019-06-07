using DAL.Context;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepos : BaseRepos<User>
    {
        public UserRepos(GSContext userContext) : base(userContext) { }

        public User GetByEmail(string email)
        {
            return GetAll().FirstOrDefault(x => x.Email == email);
        }
    }
}
