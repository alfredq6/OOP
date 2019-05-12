using _2lab11.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2lab11.ViewModels
{
    public class MainWindowModel : BaseViewModel
    {
        public ObservableCollection<SubjectViewModel> SubjectsList { get; set; }

        public MainWindowModel(List<Subject> subjects)
        {
            SubjectsList = new ObservableCollection<SubjectViewModel>(subjects.Select(x => new SubjectViewModel(x)));
        }
    }
}
