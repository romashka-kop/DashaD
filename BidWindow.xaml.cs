using DashaD.Context;
using DashaD.Models;
using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;

namespace DashaD
{
    /// <summary>
    /// Логика взаимодействия для BidWindow.xaml
    /// </summary>
    public partial class BidWindow : System.Windows.Window
    {
        private int _idBid;
        private DataGrid _grid;

        public BidWindow(int idBid, DataGrid grid)
        {
            _idBid = idBid;
            _grid = grid;
            InitializeComponent();
            SetDataOnControlls();
        }

        private void SetDataOnControlls()
        {
            using ApplicationContext context = new();
            Bid bid = context.Bids.First(a => a.IdBid == _idBid);

            var authorsForBid = context.BidAuthor
            .Where(ba => ba.IdBid == _idBid)
            .Join(
            context.Author,
            ba => ba.IdAuthor,
            a => a.IdAuthor,
            (ba, a) => new Authors { FullName = a.FullName }
            )
            .ToList();
            
            foreach (var author in authorsForBid)
            {
                AddedAuthorsList.Items.Add(author);
            }

            var paymentForBid = context.BidPayments
                .Where(bp => bp.IdBid == _idBid)
                .Join(
                context.Payments,
                bp => bp.IdPay,
                p => p.IdPay,
                (bp, p) => new Payments { File =  p.File }
                )
                .ToList();
            foreach(var payment in paymentForBid)
            {
                AddPaymentsList.Items.Add(payment);
            }
            
            var notificationForBid = context.BidNotification
                .Where(bn => bn.IdBid == _idBid)
                .Join(
                context.Notification,
                bn => bn.IdNotification,
                n => n.IdNotification,
                (bn, n) => new Notification { Name = n.Name }
                )
                .ToList();

            foreach (var notification in notificationForBid)
            {
                AddNotficationsList.Items.Add(notification);
            }

            AddedAuthorsList.Items.Refresh();

            BidNumber.Text = bid.BidNumber.ToString();
            BidDate.Text = bid.DateBid.ToString();
            BidFormula.Text = bid.Formula;
            BidDescription.Text = bid.Description;
            BidReport.Text = bid.Report;
            BidNumberDate.Text = bid.NumberDate.ToString();
            BidLetter.Text = bid.Letter;
        }

        private void BidNumberDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = BidNumberDate.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                // Можно сообщить пользователю, что поле не заполнено
                return;
            }

            // Проверяем наличие дефиса
            if (!input.Contains('-'))
            {
                ShowError("Введите значение в формате 'номер-дата' (например, 123-05.04.2025).");
                return;
            }

            string[] parts = input.Split('-');

            if (parts.Length != 2)
            {
                ShowError("Формат должен быть: номер-дата.");
                return;
            }

            string numberPart = parts[0];
            string datePart = parts[1];

            // Проверка номера
            if (!int.TryParse(numberPart, out _))
            {
                ShowError("Перед дефисом должен быть номер (целое число).");
                return;
            }

            // Проверка даты
            if (!DateTime.TryParseExact(datePart, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out _))
            {
                ShowError("После дефиса должна быть дата в формате ДД.ММ.ГГГГ.");
                return;
            }

            // Если всё верно — можно продолжить
            // Например, скрыть ошибку
            HideError();
        }

        private void ShowError(string message)
        {
            ToolTipService.SetToolTip(BidNumberDate, message);
            BidNumberDate.BorderBrush = Brushes.Red;
        }

        private void HideError()
        {
            ToolTipService.SetToolTip(BidNumberDate, null);
            BidNumberDate.BorderBrush = Brushes.Gray;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Document", "bid.docx");
            MessageBox.Show(templatePath);

            if (!File.Exists(templatePath))
            {
                MessageBox.Show("Шаблон не найден!");
                return;
            }

            var wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Visible = false;

            Document doc = wordApp.Documents.Open(templatePath);
            doc.Activate();

            ReplacePlaceholder(doc, "<НОМЕР ЗАЯВКИ>", BidNumber.Text);
            string authorsList = GetAuthorsFromListBox();
            ReplacePlaceholder(doc, "<ФИО>", authorsList);
            ReplacePlaceholder(doc, "<ФОРМУЛА>", BidFormula.Text);
            ReplacePlaceholder(doc, "<ОПИСАНИЕ>", BidDescription.Text);
            ReplacePlaceholder(doc, "<РЕФЕРАТ>", BidReport.Text);

            string tempFilePath = Path.GetTempFileName() + ".docx";
            doc.SaveAs2(tempFilePath);

            doc.PrintOut();

            doc.Close();
            wordApp.Quit();

            File.Delete(tempFilePath);
        }

        private void ReplacePlaceholder(Document doc, string placeholder, string value)
        {
            var range = doc.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(
                FindText: placeholder,
                ReplaceWith: value,
                Replace: WdReplace.wdReplaceAll);
        }

        private string GetAuthorsFromListBox()
        {
            var authors = new List<string>();

            foreach (var item in AddedAuthorsList.Items)
            {
                if (item is Authors author)
                {
                    authors.Add(author.FullName);
                }
            }

            return string.Join(Environment.NewLine, authors);
        }

        private void UpdateBid_Click(object sender, RoutedEventArgs e)
        {
            using ApplicationContext context = new ApplicationContext();

            Bid bid = (Bid)context.Bids.Where(b => b.IdBid == _idBid);
            bid.BidNumber = long.Parse(BidNumber.Text);//вот так со всеми а у меня почемуто патенты ошибку выдавали какую
            //author.Name = AuthorName.Text; только дата или номер
            context.SaveChanges();

            BidPage.View(_grid);
            this.Close();
        }
    }
}
