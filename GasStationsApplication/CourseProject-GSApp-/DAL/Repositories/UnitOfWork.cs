using DAL.Context;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSAppLogic
{
    public static class UnitOfWork
    {
        public static FuelTypesRepos fuelTypesRepos;
        public static GasStationsRepos gasStationsRepos;
        public static UserRepos userRepository;
        public static CompanyRepos companyRepos;
        public static FeedBackRepos feedBackRepos;
        
        static UnitOfWork()
        {
            GSContext db = new GSContext();
            fuelTypesRepos = new FuelTypesRepos(db);
            gasStationsRepos = new GasStationsRepos(db);
            companyRepos = new CompanyRepos(db);
            userRepository = new UserRepos(db);
            feedBackRepos = new FeedBackRepos(db);
        }
    }
}
