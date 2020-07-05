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
using System.Windows.Shapes;
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    /// 

    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void OnLoginError(string error)
        {
            MessageBox.Show(error);
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

        public void Delete()
        {
            foreach (var item in LoginGrid.Children)

            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";

                }

            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Boolean emptyUserName;
            emptyUserName = username.Text.Equals(String.Empty);
            Boolean emptyPassword;
            emptyPassword = password.Equals(String.Empty);
            bool isStFound = false;

            if (emptyUserName == true)
            {

                MessageBox.Show("Не е посочено потребителско име");

                Delete();

            }

            else if (emptyPassword == true)
            {
                MessageBox.Show("Не е посоченa парола");
                Delete();
            }
            else if (username.Text.Length < 5)
            {

                MessageBox.Show("Потребителското име е по - малкo от 5 символа");
                Delete();


            }
            else if (password.Text.Length < 5)
            {
                MessageBox.Show("Паролата е по - малка от 5 символа");
                Delete();
            }
            else
            {

                LoginValidation login = new LoginValidation(username.Text, password.Text, OnLoginError);
                User user = null;
                if (!login.ValidateUserInput(ref user))
                {
                    Delete();
                    return;
                }
                if (user.role == 4) {
                   
                    Student student = StudentValidation.GetStudentDataByUser(user);

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.DataContext = new MainFormVM() { Student = student };
                    isStFound = true;
                    mainWindow.Show();
                    Delete();
                }
                if (isStFound == false)
                {

                    MessageBox.Show("Няма такъв студент");
                    Delete();

                }
            }
            
        }
    }
}




