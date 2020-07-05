using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Timers;

namespace WpfExample
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ICommand toggleExecuteCommand
        { get; set; }
        private ICommand hiButtonCommand;
        private bool canExecute = true;
        private string labelHi = "";

        public event PropertyChangedEventHandler PropertyChanged;

        public string HiLabelContent
        {
            get { return labelHi; }
            set
            {
                if (this.labelHi != value)
                {
                    this.labelHi = value;
                    PropChanged("HiLabelContent");
                }
            }
        }
        public string HiButtonContent
        {
            get { return "click to hi"; }
        }
        public bool CanExecute
        {
            get { return this.canExecute; }
            set
            {
                if (this.canExecute == value)
                { return; }
                this.canExecute = value;
            }
        }
        
        public ICommand ToggleExecuteCommand
        {
            get
            { return toggleExecuteCommand; }
            set
            { toggleExecuteCommand = value; }
        }
        public ICommand HiButtonCommand
        {
            get
            { return hiButtonCommand; }
            set
            { hiButtonCommand = value; }
        }
        public void PropChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string CurrentDateTime
        {
            get { return DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString(); }
        }

        public MainWindowViewModel()
        {
            HiButtonCommand = new RelayCommand(ShowMessage, param => this.canExecute);
            toggleExecuteCommand = new RelayCommand(ChangeCanExecute);
            
        }
        public void ShowMessage(object obj)
        {
            HiLabelContent = obj.ToString();
        }
        public void ChangeCanExecute(object obj)
        {
            canExecute = !canExecute;
        }
        public void UpdateDateTime(object obj, ElapsedEventArgs e)
        {
            PropChanged("CurrentDateTime");
        }
    }
}