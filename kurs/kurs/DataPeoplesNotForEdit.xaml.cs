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

namespace kurs
{
    /// <summary>
    /// Логика взаимодействия для DataPeoplesNotForEdit.xaml
    /// </summary>
    public partial class DataPeoplesNotForEdit : Page
    {
        public DataPeoplesNotForEdit()
        {
            InitializeComponent();
            DGridBooks.ItemsSource = BiblitekaEntities5.GetContext().Peoples.ToList();
            UpdateClients();
        }

        private void UpdateClients()
        {
            var currentClients = BiblitekaEntities5.GetContext().Peoples.ToList();

            currentClients = currentClients.Where(p => p.name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            DGridBooks.ItemsSource = currentClients.OrderBy(p => p.name).ToList();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateClients();
        }
    }
}
