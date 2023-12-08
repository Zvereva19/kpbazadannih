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
using System.Windows.Shapes;

namespace kurs
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            Manager1.MainFrame1 = MainFrame1;
        }

        private void Books_Click(object sender, RoutedEventArgs e)
        {
            MainFrame1.Navigate(new BooksNotForEdit());
        }

        private void AllData_Click(object sender, RoutedEventArgs e)
        {
            MainFrame1.Navigate(new DataPeoplesNotForEdit());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw1 = new MainWindow();
            mw1.Show();
            this.Close();
        }
    }
}
