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
    /// Логика взаимодействия для DataPeoples.xaml
    /// </summary>
    public partial class DataPeoples : Page
    {
        public DataPeoples()
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

        private void BtnEditMark2_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Page2((sender as Button).DataContext as Peoples));
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateClients();
        }

        private void BtnAddMark2_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Page2(null));
        }

        private void BtnDel1Mark2_Click(object sender, RoutedEventArgs e)
        {
            var PeoplesForRemoving = DGridBooks.SelectedItems.Cast<Peoples>().ToList();
            if (MessageBox.Show($"Вы  точно хотите удалить {PeoplesForRemoving.Count()} пользователей?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BiblitekaEntities5.GetContext().Peoples.RemoveRange(PeoplesForRemoving);
                    BiblitekaEntities5.GetContext().SaveChanges();
                    MessageBox.Show("Операция прошла успешно");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ToString());
                    DGridBooks.ItemsSource = BiblitekaEntities5.GetContext().Book.ToList();
                }
            }
        }
    }
}
