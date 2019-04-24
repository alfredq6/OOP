using _2lab9.Contexts;
using _2lab9.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2lab9.Repository
{
    public class CompaniesRepository : BaseRepository<Company>
    {
        public LabContext _CompaniesContext { get; set; }
        public List<Company> ListOfCompanies { get; set; }

        public CompaniesRepository(LabContext companiesContext)
        {
            _CompaniesContext = companiesContext;
        }

        public Company Save(Company company)
        {
            _CompaniesContext.Companies.Add(company);
            _CompaniesContext.SaveChanges();
            return company;
        }
    }
}
