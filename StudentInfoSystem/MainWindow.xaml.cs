using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserLogin;
using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public List<string> StudStatusChoices { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            FillStudStatusChoices();

            if (GradesData.TestGradesEmpty() == true)
            {
              GradesData.CopyTestGrades();
           }


            if (StudentData.TestStudentsIfEmpty() == true) 
            {
               StudentData.CopyTestStudents();
            }

           





        }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
            SqlConnection("Server=DESKTOP-2LTM5RR\\SQLEXPRESS;" +
            "Initial Catalog=StudentInfoDatabase;" +
            "Integrated Security=true;" +
            "Trusted_Connection=true;" +
            "MultipleActiveResultSets=true"))
            {
                string sqlquery =
                @"SELECT StatusDescr FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();

                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }

                statusListBox.ItemsSource = this.StudStatusChoices;
            }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (GradesData.TestGradesEmpty() == true)
           {


              MessageBox.Show("True");

            }
           else {
               MessageBox.Show("False");
            }


        }
        public static string facNumberStudents;
        public void tema_Click(object sender, RoutedEventArgs e)
        {

            facNumberStudents = facNumber.Text;
            Dissertation mainWindow = new Dissertation();
            mainWindow.Show();
        }
    }
}

