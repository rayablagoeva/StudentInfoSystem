using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for Dissertation.xaml
    /// </summary>
    public partial class Dissertation : Window
    {
       
        public Dissertation() {

            InitializeComponent();
           
        }

        public void Delete()
        {
            foreach (var item in Diss.Children)

            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";

                }

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

        private static void createDatabase(string facNumber,String topic,string subject,string professor)
        {
            DissertationContext con = new DissertationContext();

            Dissertations diss = new Dissertations();
            diss.facNumberStudent = facNumber;
            diss.topic = topic;
            diss.subject = subject;
            diss.professor = professor;
            con.Dissertations.Add(diss);

            con.SaveChanges();
           
        


        }
       
   //public void Delete() {
       //


          //DissertationContext context = new DissertationContext();
           //issertations delObj =
         //from ds in context.Dissertations
           //where ds.DissertationId == 2            select ds).First();
         // context.Dissertations.Remove(delObj);
          //context.SaveChanges();
       //}

        void Button_Click(object sender, RoutedEventArgs e)
        {
           string t = tema.Text;
          string s = predmet.Text;
          string p = teacher.Text;
            string f = MainWindow.facNumberStudents;
            
            createDatabase(f,t,s,p);
            MessageBox.Show("Успешен запис");
            Delete();
            
           


   }
    }
}
