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
    /// Логика взаимодействия для KfedraPage.xaml
    /// </summary>
    public partial class KfedraPage : Page
    {
        public static List<Kafedra> kafedras {  get; set; }
        public static List<Disciplina> disciplinas { get; set; }
        public static Employee loggenUser;
        public KfedraPage()
        {
            InitializeComponent();
            kafedras = DbConnection.UP_LAB_2Entities.Kafedra.Where(x => x.Id_Kafedra == DbConnection.loginesUser.Abbreviatura_Employee).ToList();
            kafedras = new List<Kafedra>(DbConnection.UP_LAB_2Entities.Kafedra.ToList());
            disciplinas = new List<Disciplina>(DbConnection.UP_LAB_2Entities.Disciplina.ToList());
            TBUser.Text = DbConnection.loginesUser.FIO;
            loggenUser = DbConnection.loginesUser;
            this.DataContext = this;
        }

        private void ExitBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void KafedraLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if(KafedraLV.SelectedItem is Kafedra kafedra)
            //{
            //    KafedraLV.SelectedItem = null;
                
            //}
            NavigationService.Navigate(new AddDisceplinPage());
        }
    }
}
