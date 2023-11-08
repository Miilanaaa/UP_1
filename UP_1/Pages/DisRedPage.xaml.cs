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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UP_1.DB;

namespace UP_1.Pages
{
    /// <summary>
    /// Логика взаимодействия для DisRedPage.xaml
    /// </summary>
    public partial class DisRedPage : Page
    {
        public static List<Disciplina> disciplinas { get; set; }
        public static List<Kafedra> kafedras { get; set; }
        public static Disciplina dis { get; set; }
        Disciplina contextdisc;
        public DisRedPage(Disciplina disciplina)
        {
            InitializeComponent();
            contextdisc = disciplina;
            dis = disciplina;
            KafedraTB.Text = Convert.ToString(contextdisc.Kafedra.Name_Kafedra);
            

            disciplinas = new List<Disciplina>(DbConnection.UP_LAB_2Entities.Disciplina.ToList());
            kafedras = new List<Kafedra>(DbConnection.UP_LAB_2Entities.Kafedra.ToList());
            this.DataContext = this;
        }

        private void EBT_Click(object sender, RoutedEventArgs e)
        {
            var error = string.Empty;
            var val = new ValidationContext(contextdisc);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            if (Validator.TryValidateObject(contextdisc, val, results, true))
            {
                foreach (var result in results)
                {
                    error += $"{result.ErrorMessage}\n";
                }
            }
            if (!string.IsNullOrWhiteSpace(error))
            {
                MessageBox.Show(error);
                return;
            }
            if (contextdisc.Id_Disciplina == 0)
                DbConnection.UP_LAB_2Entities.Disciplina.Add(contextdisc);
                DbConnection.UP_LAB_2Entities.SaveChanges();
            NavigationService.GoBack();
        }

        private void EpBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddDisceplinPage());
        }
    }
}
