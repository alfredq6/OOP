using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _2lab9.Contexts;
using _2lab9.Models;
using _2lab9.Repository;

namespace _2lab9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public MainWindow()
        {
            InitializeComponent();
            using (LabContext db  = new LabContext())
            {
                unitOfWork.CompaniesUnits.ListOfCompanies = db.Companies.ToList();
                unitOfWork.EmployeesUnits.ListOfEmployees = db.Employees.ToList();
                db.SaveChanges();
            }
            

            //var company1 = new Company { Name = "Mila", Cost = 50000000, Adress = "Минск, Бобруйская 6" };
            //var company2 = new Company { Name = "Electrosila", Cost = 150000000, Adress = "Минск, Бобруйская 6" };

            //using (CompaniesContext db = new CompaniesContext())
            //{
            //    db.Companies.Add(company1);
            //    db.Companies.Add(company2);
            //    db.SaveChanges();
            //}

            //using (EmployeesContext db = new EmployeesContext())
            //{
            //    var employee1 = new Employee { Id = 1, Name = "Nikolai", Age = 24, Post = "Consultant", Wage = 400, CompanyName = company1.Name };
            //    var employee2 = new Employee { Id = 2, Name = "Olga", Age = 22, Post = "Salesman", Wage = 500, CompanyName = company1.Name };

            //    db.Employees.Add(employee1);
            //    db.Employees.Add(employee2);
            //    db.SaveChanges();
            //}

        }

        private void ShowCompanies_Click(object sender, RoutedEventArgs e)
        {
            using (LabContext db = new LabContext())
            {
                unitOfWork.CompaniesUnits._CompaniesContext = db;
                unitOfWork.CompaniesUnits.ListOfCompanies = unitOfWork.CompaniesUnits._CompaniesContext.Companies.ToList();
                DG2.DataContext = unitOfWork.CompaniesUnits.ListOfCompanies;
                db.SaveChangesAsync();
            }
        }

        private void ShowEmployees_Click(object sender, RoutedEventArgs e)
        {
            using (LabContext db = new LabContext())
            {
                unitOfWork.EmployeesUnits._EmployeesContext = db;
                unitOfWork.EmployeesUnits.ListOfEmployees = unitOfWork.EmployeesUnits._EmployeesContext.Employees.ToList();
                DG1.DataContext = unitOfWork.EmployeesUnits.ListOfEmployees;
                db.SaveChangesAsync();
            }
        }

        private void SaveEmployees_Click(object sender, RoutedEventArgs e)
        {
            if (DG1 != null && DG1.Items != null && unitOfWork.EmployeesUnits != null)
            {
                using (LabContext db = new LabContext())
                {
                    unitOfWork.EmployeesUnits._EmployeesContext = db;
                    using (var transaction = unitOfWork.EmployeesUnits._EmployeesContext.Database.BeginTransaction())
                    {
                        try
                        {
                            foreach (var employee in unitOfWork.EmployeesUnits.ListOfEmployees)
                            {
                                if (employee is Employee)
                                {
                                    if (unitOfWork.EmployeesUnits._EmployeesContext.Employees.Any(x => x.Id == employee.Id))
                                    {
                                        var emp = unitOfWork.EmployeesUnits._EmployeesContext.Employees.FirstOrDefault(el => el.Id == employee.Id);
                                        if (emp != null)
                                        {
                                            unitOfWork.EmployeesUnits._EmployeesContext.Employees.Attach(emp);
                                            emp.Name = employee.Name;
                                            emp.Post = employee.Post;
                                            emp.Wage = employee.Wage;
                                            emp.Age = employee.Age;
                                            emp.CompanyName = employee.CompanyName;
                                        }
                                        unitOfWork.EmployeesUnits._EmployeesContext.SaveChanges();
                                    }
                                    else
                                        unitOfWork.EmployeesUnits.Save(employee);
                                }
                            }

                            foreach (var employee in unitOfWork.EmployeesUnits._EmployeesContext.Employees.ToList())
                            {
                                if (!unitOfWork.EmployeesUnits.ListOfEmployees.Any(elDG => elDG.Id == employee.Id))
                                {
                                    unitOfWork.EmployeesUnits._EmployeesContext.Employees.Remove(employee);
                                }
                            }
                            transaction.Commit();
                            unitOfWork.EmployeesUnits._EmployeesContext.SaveChanges();
                            db.SaveChangesAsync();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void SaveCompanies_Click(object sender, RoutedEventArgs e)
        {
            if (DG2 != null && DG2.Items != null && unitOfWork.CompaniesUnits != null)
            {
                using (LabContext db = new LabContext())
                {
                    unitOfWork.CompaniesUnits._CompaniesContext = db;
                    unitOfWork.EmployeesUnits._EmployeesContext = db;
                    foreach (var company in unitOfWork.CompaniesUnits.ListOfCompanies)
                    {
                        if (company is Company)
                        {
                            if (unitOfWork.CompaniesUnits._CompaniesContext.Companies.Any(x => x.Name == company.Name))
                            {
                                var el = unitOfWork.CompaniesUnits._CompaniesContext.Companies.FirstOrDefault(elDB => elDB.Name == company.Name);
                                var emp = unitOfWork.EmployeesUnits._EmployeesContext.Employees.FirstOrDefault(empDB => empDB.CompanyName == el.Name);
                                if (emp != null)
                                {
                                    unitOfWork.EmployeesUnits._EmployeesContext.Employees.Attach(emp);
                                    emp.CompanyName = company.Name;
                                }
                                if (el != null)
                                {
                                    unitOfWork.CompaniesUnits._CompaniesContext.Companies.Attach(el);
                                    el.Cost = company.Cost;
                                    el.Adress = company.Adress;
                                    el.Name = company.Name;
                                }
                                unitOfWork.EmployeesUnits._EmployeesContext.SaveChanges();
                                unitOfWork.CompaniesUnits._CompaniesContext.SaveChanges();
                            }
                            else
                                unitOfWork.CompaniesUnits.Save(company);
                        }
                    }

                    foreach (var el in unitOfWork.CompaniesUnits._CompaniesContext.Companies.ToList())
                    {
                        if (!unitOfWork.CompaniesUnits.ListOfCompanies.Any(elDG => el.Name == elDG.Name))
                        {
                            if (unitOfWork.EmployeesUnits.ListOfEmployees.Any(elDG => elDG.CompanyName == el.Name))
                                unitOfWork.EmployeesUnits._EmployeesContext.Employees.RemoveRange(unitOfWork.EmployeesUnits._EmployeesContext.Employees.Where(x => x.CompanyName == el.Name));
                            unitOfWork.CompaniesUnits._CompaniesContext.Companies.Remove(el);
                        }
                    }
                    unitOfWork.EmployeesUnits._EmployeesContext.SaveChanges();
                    unitOfWork.CompaniesUnits._CompaniesContext.SaveChanges();
                    db.SaveChangesAsync();
                }
            }
        }


        private void SearchCompanies_Click(object sender, RoutedEventArgs e)
        {
            Company findingObject = null;
            var list = new List<Company>();
            using (LabContext db = new LabContext())
            {
                unitOfWork.CompaniesUnits._CompaniesContext = db;
                if (CompanyNameTxtBlock.Text.Count() != 0)
                {
                    findingObject = unitOfWork.CompaniesUnits._CompaniesContext.Companies.Find(CompanyNameTxtBlock.Text);
                }

                if (CompanyCostTxtBlock.Text.Count() != 0)
                {
                    int cost = 0;
                    if (Int32.TryParse(CompanyCostTxtBlock.Text, out cost))
                    {
                        if (CompanyNameTxtBlock.Text.Count() == 0)
                        {
                            list = unitOfWork.CompaniesUnits._CompaniesContext.Companies.ToList().Where(x => x.Cost <= cost).ToList();
                        }
                        else
                        {
                            if (findingObject != null && findingObject.Cost <= cost)
                            {
                                list.Add(findingObject);
                            }
                        }
                    }
                }
                else
                {
                    if (findingObject != null)
                        list.Add(findingObject);
                }

                DG2.DataContext = list;

                unitOfWork.CompaniesUnits._CompaniesContext.SaveChangesAsync();
                db.SaveChangesAsync();
            }

        }

        private void SearchEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee findingObject = null;
            var list = new List<Employee>();
            using (LabContext db = new LabContext())
            {
                unitOfWork.EmployeesUnits._EmployeesContext = db;
                if (EmpNameTxtBox.Text.Count() != 0)
                {
                    findingObject = unitOfWork.EmployeesUnits._EmployeesContext.Employees.Where(x => x.Name == EmpNameTxtBox.Text).FirstOrDefault();
                }

                if (EmpAgeTxtBox.Text.Count() != 0)
                {
                    int age = 0;
                    if (Int32.TryParse(EmpAgeTxtBox.Text, out age))
                    {
                        if (EmpNameTxtBox.Text.Count() == 0)
                        {
                            list = unitOfWork.EmployeesUnits._EmployeesContext.Employees.ToList().Where(x => x.Age <= age).ToList();
                        }
                        else
                        {
                            if (findingObject != null && findingObject.Age <= age)
                            {
                                list.Add(findingObject);
                            }
                        }
                    }
                }
                else
                {
                    if (findingObject != null)
                        list.Add(findingObject);
                }

                DG1.DataContext = list;

                unitOfWork.EmployeesUnits._EmployeesContext.SaveChangesAsync();
                db.SaveChangesAsync();
            }
        }

        private void SortByName_Click(object sender, RoutedEventArgs e)
        {
            unitOfWork.EmployeesUnits.ListOfEmployees = unitOfWork.EmployeesUnits.ListOfEmployees.OrderBy(x => x.Name).ToList();
            DG1.DataContext = unitOfWork.EmployeesUnits.ListOfEmployees;
        }

        private void SortByAge_Click(object sender, RoutedEventArgs e)
        {
            unitOfWork.EmployeesUnits.ListOfEmployees = unitOfWork.EmployeesUnits.ListOfEmployees.OrderBy(x => x.Age).ToList();
            DG1.DataContext = unitOfWork.EmployeesUnits.ListOfEmployees;
        }

        private void SortByWage_Click(object sender, RoutedEventArgs e)
        {
            unitOfWork.EmployeesUnits.ListOfEmployees = unitOfWork.EmployeesUnits.ListOfEmployees.OrderBy(x => x.Wage).ToList();
            DG1.DataContext = unitOfWork.EmployeesUnits.ListOfEmployees;
        }

        private void SortByPost_Click(object sender, RoutedEventArgs e)
        {
            unitOfWork.EmployeesUnits.ListOfEmployees = unitOfWork.EmployeesUnits.ListOfEmployees.OrderBy(x => x.Post).ToList();
            DG1.DataContext = unitOfWork.EmployeesUnits.ListOfEmployees;
        }

        private void SortByCompName_Click(object sender, RoutedEventArgs e)
        {
            unitOfWork.CompaniesUnits.ListOfCompanies = unitOfWork.CompaniesUnits.ListOfCompanies.OrderBy(x => x.Name).ToList();
            DG2.DataContext = unitOfWork.CompaniesUnits.ListOfCompanies;
        }

        private void SortByCost_Click(object sender, RoutedEventArgs e)
        {
            unitOfWork.CompaniesUnits.ListOfCompanies = unitOfWork.CompaniesUnits.ListOfCompanies.OrderBy(x => x.Cost).ToList();
            DG2.DataContext = unitOfWork.CompaniesUnits.ListOfCompanies;
        }

        private void SortByAdress_Click(object sender, RoutedEventArgs e)
        {
            unitOfWork.CompaniesUnits.ListOfCompanies = unitOfWork.CompaniesUnits.ListOfCompanies.OrderBy(x => x.Adress).ToList();
            DG2.DataContext = unitOfWork.CompaniesUnits.ListOfCompanies;
        }
    }
}