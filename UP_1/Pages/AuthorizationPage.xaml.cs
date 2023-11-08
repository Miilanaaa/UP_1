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
using UP_1.DB;

namespace UP_1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static List<Employee> employees {  get; set; }
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void logiBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListDisciplinaPage());
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTb.Text.Trim();
            string password = passwordTb.Password.Trim();

            employees = new List<Employee>(DbConnection.UP_LAB_2Entities.Employee.ToList());
            var currentUser = employees.FirstOrDefault(i => i.Login == login && i.Password == password);
            DbConnection.loginesUser = currentUser;
            if (currentUser != null && currentUser.Post == "преподаватель")
            {
                MessageBox.Show("преподаватель");
                NavigationService.Navigate(new EkzamenPage());
            }  
            else if (currentUser != null && currentUser.Post == "зав. кафедрой")
            {
                MessageBox.Show("зав. кафедрой");
                NavigationService.Navigate(new KfedraPage());
            }
                
            else if (currentUser != null && currentUser.Post == "инженер")
            {
                MessageBox.Show("инженер");
                NavigationService.Navigate(new EmployeePage());
            }
               
            else
                MessageBox.Show("НЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕТ");

        }
    }
}
