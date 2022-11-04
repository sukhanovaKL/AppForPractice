using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Word = Microsoft.Office.Interop.Word;

namespace AppForPractice
{
    /// <summary>
    /// Логика взаимодействия для TarifsWindow.xaml
    /// </summary>
    public partial class TarifsWindow : Window
    {
        practica_5Entities db = new practica_5Entities();
        public TarifsWindow()
        {
            InitializeComponent();
            data.ItemsSource = db.InternetPrice.ToList();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            var f = (sender as Button).DataContext as InternetPrice;
            EditTarifWindow redact = new EditTarifWindow(f);
            redact.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var f = (sender as Button).DataContext as InternetPrice;
            new DeleteTarifWindow(f).Show();
            Hide();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new AddTarifWindow().Show();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            var allItems = db.InternetPrice.ToList();

            var app = new Word.Application();
            Word.Document document = app.Documents.Add();

            Word.Paragraph paragraph = document.Paragraphs.Add();
            Word.Range range = paragraph.Range;
            range.Text = "Тарифы";
            paragraph.set_Style("Заголовок 1");
            range.InsertParagraphAfter();

            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table tarifsTable = document.Tables.Add(tableRange, allItems.Count() + 1, 5);

            tarifsTable.Borders.InsideLineStyle = tarifsTable.Borders.OutsideLineStyle =
            Word.WdLineStyle.wdLineStyleSingle;

            Word.Range cellRange;
            tarifsTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            cellRange = tarifsTable.Cell(1, 1).Range;
            cellRange.Text = "Номер";
            cellRange = tarifsTable.Cell(1, 2).Range;
            cellRange.Text = "Дата";
            cellRange = tarifsTable.Cell(1, 3).Range;
            cellRange.Text = "Стоимость минуты";
            cellRange = tarifsTable.Cell(1, 4).Range;
            cellRange.Text = "Льготная стоимость минуты с 20 до 2";
            cellRange = tarifsTable.Cell(1, 5).Range;
            cellRange.Text = "Льготная стоимость минуты с 2 до 6";
            tarifsTable.Rows[1].Range.Bold = 1;
            tarifsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            int i = 1;

            foreach (var item in allItems)
            {

                cellRange = tarifsTable.Cell(i + 1, 1).Range;
                cellRange.Text = item.InternetPricesId.ToString();
                cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                cellRange = tarifsTable.Cell(i + 1, 2).Range;
                cellRange.Text = item.Date.ToString();
                cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                cellRange = tarifsTable.Cell(i + 1, 3).Range;
                cellRange.Text = item.CostMinute.ToString();
                cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                cellRange = tarifsTable.Cell(i + 1, 4).Range;
                cellRange.Text = item.PreferentialCost_at20to2_.ToString();
                cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                cellRange = tarifsTable.Cell(i + 1, 5).Range;
                cellRange.Text = item.PreferentialCost_at2to6_.ToString();
                cellRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                i++;

            }
            app.Visible = true;
            document.SaveAs2(@"D:\outputFilePdf.pdf", Word.WdExportFormat.wdExportFormatPDF);
            MessageBox.Show("Успешно");
        }
    }
}
