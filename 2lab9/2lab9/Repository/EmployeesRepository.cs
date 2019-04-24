using _2lab9.Contexts;
using _2lab9.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab9.Repository
{
    public class EmployeesRepository : BaseRepository<Employee>
    {
        public LabContext _EmployeesContext { get; set; }
        public List<Employee> ListOfEmployees { get; set; }

        public EmployeesRepository(LabContext employeesContext)
        {
            _EmployeesContext = employeesContext;
        }

        public Employee Save(Employee employee)
        {
            _EmployeesContext.Employees.Add(employee);
            _EmployeesContext.SaveChanges();
            return employee;
        }
    }
}
