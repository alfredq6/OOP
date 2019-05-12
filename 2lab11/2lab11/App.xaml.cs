using _2lab11.Contexts;
using _2lab11.Models;
using _2lab11.ViewModels;
using _2lab11.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _2lab11
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            List<Subject> listOfSubjects;
            using (CoursesContext db = new CoursesContext())
            {
                listOfSubjects = db.Subjects.ToList();
            }
            MainWindow view = new MainWindow();
            view.Show();
        }
    }
}
