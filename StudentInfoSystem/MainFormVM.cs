using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace StudentInfoSystem
{
    public class MainFormVM : INotifyPropertyChanged
    {
        private ICommand disableCommand;
        private ICommand clearCommand;


        public ICommand DisableCommand
        {
            get { return disableCommand; }
        }

        public ICommand ClearCommand
        {
            get { return clearCommand; }
        }

        private Student student = null;
        public Student Student
        {
            get { return student; }
            set
            {
                student = value;
                PropChanged("Student");
                
            }
        }

        private bool formEnabled = true;

        public bool FormEnabled
        {
            get { return formEnabled; }
            set { formEnabled = value; PropChanged("FormEnabled"); }
        }

        public MainFormVM()
        {
            disableCommand = new RelayCommand(_ => FormEnabled = !FormEnabled);
            clearCommand = new RelayCommand(_ => Student = null, param => FormEnabled);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void PropChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}