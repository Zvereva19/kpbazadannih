using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private Book _currentBook = new Book(); 
        public Page1(Book selectedBook)
        {
            InitializeComponent();

            if (selectedBook != null)
                _currentBook = selectedBook;

            DataContext = _currentBook;
        }

        private void BtnSaveAndExit_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentBook.name))
                errors.AppendLine("Укажите название книги.");
            if (string.IsNullOrWhiteSpace(_currentBook.author))
                errors.AppendLine("Укажите Автора книги.");
            if (string.IsNullOrWhiteSpace(_currentBook.genre))
                errors.AppendLine("Укажите жанр книги.");
            if (_currentBook.year < 1)
                errors.AppendLine("Укажите год написания книги.");
            if (_currentBook.Availability == null)
                errors.AppendLine("Книги не существует? Тут надо ввести True(есть в наличии) False(нет в наличии).");
            if (_currentBook.Cost == null)
                errors.AppendLine("Укажите стоимость книг.");
            if (_currentBook.Quantity == null)
                errors.AppendLine("Укажите количество книг.");
            if (_currentBook.Pages == null)
                errors.AppendLine("Укажите количество страниц книги.");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            // тут идет проверка на ввод данных

            if (_currentBook.id == 0)
                BiblitekaEntities5.GetContext().Book.Add(_currentBook);
            try
            {
                BiblitekaEntities5.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }
            // окно с сообщением
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
        }
    }
}
