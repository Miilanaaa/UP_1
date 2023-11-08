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
    /// Логика взаимодействия для AddDisceplinPage.xaml
    /// </summary>
    public partial class AddDisceplinPage : Page
    {
        public static List<Disciplina> disciplinas { get; set; }
        public static List<Kafedra> kafedras { get; set; }
        

        public AddDisceplinPage()
        {
            InitializeComponent();
            disciplinas = new List<Disciplina>(DbConnection.UP_LAB_2Entities.Disciplina.ToList());
            kafedras = new List<Kafedra>(DbConnection.UP_LAB_2Entities.Kafedra.ToList());
            this.DataContext = this;
        }

        private void ExitBT_Click(object sender, RoutedEventArgs e)
        {
            Disciplina disciplina = new Disciplina();
            disciplina.Name_Disciplina = NameDisTB.Text.Trim();
            disciplina.Shifr = KafedraCB.SelectedIndex;

            DbConnection.UP_LAB_2Entities.Disciplina.Add(disciplina);
            DbConnection.UP_LAB_2Entities.SaveChanges();
            MessageBox.Show("Вы добавили новую дисциплину");
        }

        private void EBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new KfedraPage());
        }

        private void DelBT_Click(object sender, RoutedEventArgs e)
        {
            var DisForDel = KafedraLV.SelectedItem as Disciplina;
            var DisList = DbConnection.UP_LAB_2Entities.Disciplina.Where(x => x.Id_Disciplina == DisForDel.Id_Disciplina).ToList().FirstOrDefault();
            if (DisList != null)
            {
                DbConnection.UP_LAB_2Entities.Disciplina.Remove(DisList);
                DbConnection.UP_LAB_2Entities.SaveChanges();
                MessageBox.Show("Вы удалили дисциплину");
            }
            else
            {
                MessageBox.Show("Эта дисциплина удалена");
            }
        }

        private void RedBT_Click(object sender, RoutedEventArgs e)
        {
            if (KafedraLV.SelectedItem is Disciplina disciplina)
            {
                KafedraLV.SelectedItem = null;
                NavigationService.Navigate(new DisRedPage(disciplina));
            }
            
        }
    }
}
