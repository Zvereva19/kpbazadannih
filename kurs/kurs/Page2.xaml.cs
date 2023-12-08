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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private Peoples _currentPeople = new Peoples();
        public Page2(Peoples selectedPeople)
        {
            InitializeComponent();

            if (selectedPeople != null)
                _currentPeople = selectedPeople;

            DataContext = _currentPeople;
        }

        private void BtnSaveAndExit_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentPeople.name))
                errors.AppendLine("Укажите имя клиента.");
            if (string.IsNullOrWhiteSpace(_currentPeople.surname))
                errors.AppendLine("Укажите фамилию клиента.");
            if (string.IsNullOrWhiteSpace(_currentPeople.patronymic))
                errors.AppendLine("Укажите отчество клиента.");
            if (_currentPeople.book_name == null)
                errors.AppendLine("Укажите название книги.");
            if (_currentPeople.genre == null)
                errors.AppendLine("Укажите жанр книги.");
            if (_currentPeople.Pages == null)
                errors.AppendLine("Укажите колл-во страниц в книге.");
            if (_currentPeople.Cost == null)
                errors.AppendLine("Укажите стоимость книг.");
            if (_currentPeople.date_issue == null)
                errors.AppendLine("Укажите когда человек получил/получает книгу.");
            if (_currentPeople.date_admission == null)
                errors.AppendLine("Укажите когда человек должен вернуть книгу.");
            if (_currentPeople.book_availability == null)
                errors.AppendLine("Укажите вернул ли книгу человек.");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            // тут идет проверка на ввод данных

            if (_currentPeople.id == 0)
                BiblitekaEntities5.GetContext().Peoples.Add(_currentPeople);
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
