﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseReport.xaml
    /// </summary>
    public partial class ExpenseReport : Window
    {
        public ExpenseReport()
        {
            InitializeComponent();
        }
        public ExpenseReport(object data)
            : this()

        {

            // Bind to expense report data.
            this.DataContext = data;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Сигурни ли сте,че искате да затворите прозореца ?", "Изход", MessageBoxButton.YesNo);
            Console.WriteLine(result);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

       
    }
}
