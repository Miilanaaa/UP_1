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
    /// Логика взаимодействия для EkzamenPage.xaml
    /// </summary>
    public partial class EkzamenPage : Page
    {
        public static List<Ekzamen> ekzamens {  get; set; }
        public static List<Students> students { get; set; }
        public static List<Employee> employees { get; set; }
        public static List<Disciplina> disciplinas { get; set; }
        public static Employee loggedUser;

        public EkzamenPage()
        {
            InitializeComponent();
            TBUser.Text = DbConnection.loginesUser.FIO;
            ekzamens = new List<Ekzamen>(DbConnection.UP_LAB_2Entities.Ekzamen.Where(x => x.Id_Employee == DbConnection.loginesUser.Id_Employee).ToList());
            students = new List<Students>(DbConnection.UP_LAB_2Entities.Students.ToList());
            employees = new List<Employee>(DbConnection.UP_LAB_2Entities.Employee.ToList());
            disciplinas = new List<Disciplina>(DbConnection.UP_LAB_2Entities.Disciplina.ToList());
            loggedUser = DbConnection.loginesUser;
            this.DataContext = this;
        }

        private void ExamLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ExamLV.SelectedItem is Ekzamen exam)
            {
                ExamLV.SelectedItem = null;
                NavigationService.Navigate(new AddExamPage(exam));
            }
        }

        private void ExitBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
