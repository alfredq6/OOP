using _2lab9.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab9.Repository
{
    public class UnitOfWork : IDisposable
    {
        private LabContext db = new LabContext();
        private CompaniesRepository _companiesRepository;
        private EmployeesRepository _employeesRepository;

        public EmployeesRepository EmployeesUnits
        {
            get
            {
                if (_employeesRepository == null)
                    _employeesRepository = new EmployeesRepository(db);
                return _employeesRepository;
            }
        }

        public CompaniesRepository CompaniesUnits
        {
            get
            {
                if (_companiesRepository == null)
                    _companiesRepository = new CompaniesRepository(db);
                return _companiesRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

