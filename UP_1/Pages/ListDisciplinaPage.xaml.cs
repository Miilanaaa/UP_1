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
    /// Логика взаимодействия для ListDisciplinaPage.xaml
    /// </summary>
    public partial class ListDisciplinaPage : Page
    {
        public static List<Disciplina> disciplinas { get; set; }
        public static List<Kafedra> kafedras { get; set; }
        public ListDisciplinaPage()
        {
            InitializeComponent();
            disciplinas = new List<Disciplina>(DbConnection.UP_LAB_2Entities.Disciplina.ToList());
            kafedras = new List<Kafedra>(DbConnection.UP_LAB_2Entities.Kafedra.ToList());
            this.DataContext = this;
        }

        private void ExitBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
