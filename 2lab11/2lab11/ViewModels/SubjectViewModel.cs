using _2lab11.Commands;
using _2lab11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _2lab11.ViewModels
{
    public class SubjectViewModel : BaseViewModel
    {
        public Subject Subject;

        public SubjectViewModel(Subject subject)
        {
            this.Subject = subject;
        }

        public string Name
        {
            get { return Subject.Name; }
            set
            {
                Subject.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string LectorName
        {
            get { return Subject.LectorName; }
            set
            {
                Subject.LectorName = value;
                OnPropertyChanged("LectorName");
            }
        }

        public int HoursNumber
        {
            get { return Subject.HoursNumber; }
            set
            {
                Subject.HoursNumber = value;
                OnPropertyChanged("HoursNumber");
            }
        }

        public int StudentsNumber
        {
            get { return Subject.StudentsNumber; }
            set
            {
                Subject.StudentsNumber = value;
                OnPropertyChanged("StudentsNumber");
            }
        }

        private ICommand writeCommand;
        public ICommand WriteCommand
        {
            get
            {
                return writeCommand ??
                    (writeCommand = new CounterCommand(GetItem));
            }
        }

        private ICommand unWriteCommand;
        public ICommand UnWriteCommand
        {
            get
            {
                return unWriteCommand ??
                    (unWriteCommand = new CounterCommand(GiveItem, CanGiveItem));
            }
        }

        private void GetItem()
        {
            StudentsNumber++;
        }

        private void GiveItem()
        {
            StudentsNumber--;
        }

        private bool CanGiveItem()
        {
            return StudentsNumber > 0;
        }

    }
}
