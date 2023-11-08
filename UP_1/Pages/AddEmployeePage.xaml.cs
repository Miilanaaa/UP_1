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
    /// Логика взаимодействия для AddEmployeePage.xaml
    /// </summary>
    public partial class AddEmployeePage : Page
    {
        public static List<Employee> employees { get; set; }
        Employee contextEmployee;


        public AddEmployeePage(Employee employee)
        {
            InitializeComponent();
            contextEmployee = employee;
            InitializeDataInPage();
            this.DataContext = this;
        }
        private void InitializeDataInPage()
        {
            employees = new List<Employee>(DbConnection.UP_LAB_2Entities.Employee.ToList());
            this.DataContext = this;
        }


        private void EBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeePage());
        }

        private void ExitBT_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();
            employee.FIO = Em_SurnameTB.Text.Trim();
            employee.Post = DoljnostCB.Text.Trim();

            MessageBox.Show("Вы добавили сотрудника");
            DbConnection.UP_LAB_2Entities.Employee.Add(employee);
            DbConnection.UP_LAB_2Entities.SaveChanges();
        }

        private void DelBT_Click(object sender, RoutedEventArgs e)
        {
            var EmpForDel = EmployeeLV.SelectedItem as Employee;
            var PtepForDel = EmployeeLV.SelectedItem as Prepodovatel;
            var ZavForDel = EmployeeLV.SelectedItem as Zav_kafedroy;
            var InshForDel = EmployeeLV.SelectedItem as Inshener;
            var EmpList = DbConnection.UP_LAB_2Entities.Employee.Where(x => x.Id_Employee == EmpForDel.Id_Employee).ToList().FirstOrDefault();
            if (EmpList != null)
            {
                MessageBox.Show("Вы удалили сотрудника");
                DbConnection.UP_LAB_2Entities.Employee.Remove(EmpList);
                DbConnection.UP_LAB_2Entities.SaveChanges();
            }
            else
            {
                MessageBox.Show("Этот сотрудника уже удален");
            }
            
        }
    }
}
