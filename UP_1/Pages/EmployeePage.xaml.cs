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
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public static List<Employee> employees { get; set; }
        public static Employee loggedUser;
        public EmployeePage()
        {
            InitializeComponent();
            TBUser.Text = DbConnection.loginesUser.FIO;
            employees = new List<Employee>(DbConnection.UP_LAB_2Entities.Employee.ToList());
            loggedUser = DbConnection.loginesUser;
            this.DataContext = this;
        }

        private void StudentExemLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeeLV.SelectedItem is Employee employee)
            {
                EmployeeLV.SelectedItem = null;
                NavigationService.Navigate(new AddEmployeePage(employee));
            }
        }

        private void ExitBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
