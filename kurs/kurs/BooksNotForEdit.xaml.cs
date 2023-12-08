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
    /// Логика взаимодействия для BooksNotForEdit.xaml
    /// </summary>
    public partial class BooksNotForEdit : Page
    {
        public BooksNotForEdit()
        {
            InitializeComponent();
            DGridBooks.ItemsSource = BiblitekaEntities5.GetContext().Book.ToList();
            UpdateClients();
        }

        private void UpdateClients()
        {
            var currentBook =BiblitekaEntities5.GetContext().Book.ToList();

            currentBook = currentBook.Where(p => p.name.ToLower().Contains(TBoxSearch1.Text.ToLower())).ToList();
            DGridBooks.ItemsSource = currentBook.OrderBy(p => p.name).ToList();
        }

        private void TBoxSearch1_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateClients();
        }
    }
}



