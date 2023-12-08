using Microsoft.Office.Interop.Word;
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
using Page = System.Windows.Controls.Page;
using Word = Microsoft.Office.Interop.Word;

namespace kurs
{
    /// <summary>
    /// Логика взаимодействия для BooksForEdit.xaml
    /// </summary>
    public partial class BooksForEdit : Page
    {
        public BooksForEdit()
        {
            InitializeComponent();
            DGridBooks.ItemsSource = BiblitekaEntities5.GetContext().Book.ToList();
            UpdateClients();
        }

        private void UpdateClients()
        {
            var currentBook = BiblitekaEntities5.GetContext().Book.ToList();

            currentBook = currentBook.Where(p => p.name.ToLower().Contains(TBoxSearch1.Text.ToLower())).ToList();
            DGridBooks.ItemsSource = currentBook.OrderBy(p => p.name).ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Page1((sender as Button).DataContext as Book));
        }

        private void TBoxSearch1TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateClients();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Page1(null));
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var BookForRemoving = DGridBooks.SelectedItems.Cast<Book>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {BookForRemoving.Count()} книг?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BiblitekaEntities5.GetContext().Book.RemoveRange(BookForRemoving);
                    BiblitekaEntities5.GetContext().SaveChanges();
                    UpdateClients();
                    MessageBox.Show("Операция прошла успешно!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ToString());
                    DGridBooks.ItemsSource = BiblitekaEntities5.GetContext().Book.ToList();
                }
            }
        }

        private void DGridBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Otchet_Click(object sender, RoutedEventArgs e)
        {
            var allRequest = BiblitekaEntities5.GetContext().Book.ToList();

            var application = new Word.Application();

            Word.Document document = application.Documents.Add();

            Word.Paragraph userParagraph = document.Paragraphs.Add();
            Word.Range userRange = userParagraph.Range;
            userRange.Text = "Книги";

            userRange.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table paymentsTable = document.Tables.Add(tableRange, allRequest.Count() + 1, 8);
            paymentsTable.Borders.InsideLineStyle = paymentsTable.Borders.OutsideLineStyle
                = Word.WdLineStyle.wdLineStyleSingle;
            paymentsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            Word.Range cellRange;

            cellRange = paymentsTable.Cell(1, 1).Range;
            cellRange.Text = "Название";
            cellRange = paymentsTable.Cell(1, 2).Range;
            cellRange.Text = "Автор";
            cellRange = paymentsTable.Cell(1, 3).Range;
            cellRange.Text = "Жанр";
            cellRange = paymentsTable.Cell(1, 4).Range;
            cellRange.Text = "Год";
            cellRange = paymentsTable.Cell(1, 5).Range;
            cellRange.Text = "Количество";
            cellRange = paymentsTable.Cell(1, 6).Range;
            cellRange.Text = "Наличие";
            cellRange = paymentsTable.Cell(1, 7).Range;
            cellRange.Text = "Стоимость";
            cellRange = paymentsTable.Cell(1, 8).Range;
            cellRange.Text = "Колл-во страниц";

            paymentsTable.Rows[1].Range.Bold = 1;
            paymentsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 0; i < allRequest.Count(); i++)
            {
                var currentCategory = allRequest[i];
                cellRange = paymentsTable.Cell(i + 2, 1).Range;
                cellRange.Text = Convert.ToString(currentCategory.name);
                cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                cellRange = paymentsTable.Cell(i + 2, 2).Range;
                cellRange.Text = Convert.ToString(currentCategory.author);

                cellRange = paymentsTable.Cell(i + 2, 3).Range;
                cellRange.Text = Convert.ToString(currentCategory.genre); 

                cellRange = paymentsTable.Cell(i + 2, 4).Range;
                cellRange.Text = Convert.ToString(currentCategory.year);

                cellRange = paymentsTable.Cell(i + 2, 5).Range;
                cellRange.Text = Convert.ToString(currentCategory.Quantity);
                cellRange = paymentsTable.Cell(i + 2, 6).Range;
                cellRange.Text = Convert.ToString(currentCategory.Availability);
                cellRange = paymentsTable.Cell(i + 2, 7).Range;
                cellRange.Text = Convert.ToString(currentCategory.Cost);
                cellRange = paymentsTable.Cell(i + 2, 8).Range;
                cellRange.Text = Convert.ToString(currentCategory.Quantity);


            }

            application.Visible = true;
        }

        private void DGridBooks_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
