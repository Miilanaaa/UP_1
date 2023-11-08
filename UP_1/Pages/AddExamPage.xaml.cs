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
    /// Логика взаимодействия для AddExamPage.xaml
    /// </summary>
    public partial class AddExamPage : Page
    {
        public static List<Students> students { get; set; }  
        public static List<Ekzamen> ekzamens { get; set; }
        Ekzamen contextExam;
        public AddExamPage(Ekzamen exem)
        {
            InitializeComponent();
            contextExam = exem;
            InitializeDataInPage();
            this.DataContext = this;
            
        }
        private void InitializeDataInPage()
        {
            StudentCB.ItemsSource = DbConnection.UP_LAB_2Entities.Students.ToList();
            students = new List<Students>(DbConnection.UP_LAB_2Entities.Students.ToList());
            ekzamens = new List<Ekzamen>(DbConnection.UP_LAB_2Entities.Ekzamen.ToList());
        }

        private void ExitBT_Click(object sender, RoutedEventArgs e)
        {
            int mark = 0;
            var TBmark = OcenkaCB.SelectedIndex;
           
            if (TBmark != null)
            {
                if (TBmark == 0)
                {
                    mark = 2;
                }
                if (TBmark == 1)
                {
                    mark = 3;
                }
                if (TBmark == 2)
                {
                    mark = 4;
                }
                if (TBmark == 3)
                {
                    mark = 5;
                }
            }
            if (StudentCB.SelectedItem is Students students)
            {
                if (mark != null)
                {
                    var exem = contextExam;
                    exem.Students = students;
                    exem.Ocenka = Convert.ToInt32(mark);
                    var studentInList = ekzamens.FirstOrDefault(x => x.Id_students == students.Id_students);
                    MessageBox.Show("Студент успешно записан");
                    DbConnection.UP_LAB_2Entities.Ekzamen.Add(exem);
                    DbConnection.UP_LAB_2Entities.SaveChanges();
                    InitializeDataInPage();
                }
            }
        }

        private void EBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EkzamenPage());
        }

        private void DelBT_Click(object sender, RoutedEventArgs e)
        {
            var studForDel = StudentExemLV.SelectedItem as Students;
            var studList = DbConnection.UP_LAB_2Entities.Ekzamen.Where(x => x.Id == contextExam.Id && x.Id_students == studForDel.Id_students).ToList().FirstOrDefault();
            if (studList != null)
            {
                MessageBox.Show("Студент удален");
                DbConnection.UP_LAB_2Entities.Ekzamen.Remove(studList);
                DbConnection.UP_LAB_2Entities.SaveChanges();
            }
            else
            {
                MessageBox.Show("Студента нет в расписании");
            }
        }
    }
}
