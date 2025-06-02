using DashaD.Context;
using DashaD.Models;
using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DashaD
{
    /// <summary>
    /// Логика взаимодействия для AddBidWindow.xaml
    /// </summary>
    public partial class AddBidWindow : Window
    {
        private bool _isUpdating = false;

        private DataGrid _grid;

        private static string _filePath = "";
        public AddBidWindow(DataGrid grid)
        {
            _grid = grid;
            InitializeComponent();
            DataContext = this;
        }

        private void DateInputTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
        }

        private void DateInputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_isUpdating) return;

            var textBox = sender as TextBox;
            string text = textBox.Text;

            string digitsOnly = RemoveNonDigits(text);

            _isUpdating = true;

            if (digitsOnly.Length > 8)
                digitsOnly = digitsOnly.Substring(0, 8);

            StringBuilder formatted = new StringBuilder();

            for (int i = 0; i < digitsOnly.Length; i++)
            {
                if (i == 2 || i == 4)
                    formatted.Append('.');

                formatted.Append(digitsOnly[i]);
            }

            textBox.Text = formatted.ToString();
            textBox.CaretIndex = textBox.Text.Length;

            _isUpdating = false;
        }

        private string RemoveNonDigits(string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }

        private void AddBid_Click(object sender, RoutedEventArgs e)
        {
            using ApplicationContext context = new ApplicationContext();

            string input = BidNumberDate.Text.Trim();

            string pattern = @"^\d+-\d{2}\.\d{2}\.\d{4}$";

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Поле 'Номер-Дата' не может быть пустым.", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(input, pattern))
            {
                MessageBox.Show("Неверный формат!\nВведите в формате: Номер-ДД.ММ.ГГГГ\nПример: 123-01.01.2025",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            

            context.Bids.Add(new Models.Bid
            {
                BidNumber = long.Parse(BidNumber.Text),
                DateBid = DateOnly.ParseExact(BidDate.Text, "dd.MM.yyyy"),
                Formula = BidFormula.Text,
                Description = BidDescription.Text,
                Report = BidReport.Text,
                NumberDate = BidNumberDate.Text,
                Letter = BidLetter.Text,
            });

            context.SaveChanges();
            
            foreach (Payments item in AddPaymentsList.Items)
            {
                context.BidPayments.Add(new BidPayments
                {
                    IdBid = context.Bids.Where(b => b.BidNumber == long.Parse(BidNumber.Text))
                        .Select(b => b.IdBid).FirstOrDefault(),
                    IdPay = item.IdPay,
                });
            }

            foreach (Notification item in AddNotificationsList.Items)
            {
                context.BidNotification.Add(new BidNotification
                {
                    IdBid = context.Bids.Where(b => b.BidNumber == long.Parse(BidNumber.Text))
                        .Select(b => b.IdBid).FirstOrDefault(),
                    IdNotification = item.IdNotification,
                });
            }

            foreach (Authors item in AddedAuthorsList.Items)
            {
                context.BidAuthor.Add(new BidAuthor
                {
                    IdBid = context.Bids.Where(b => b.BidNumber == long.Parse(BidNumber.Text))
                        .Select(b => b.IdBid).FirstOrDefault(),
                    IdAuthor = item.IdAuthor,
                });
            }

            context.SaveChanges();

            BidPage.View(_grid);
            ClearTextBoxes();

        }

        private void ClearTextBoxes()
        {
            BidNumber.Clear();
            BidDate.Clear();
            BidFormula.Clear();
            BidDescription.Clear();
            BidReport.Clear();
            BidNumberDate.Clear();
            BidLetter.Clear();
            AddedAuthorsList.Items.Clear();
            NotificationName.Clear();
            NotificationAddressee.Clear();
            NotificationMessage.Clear();
            AddPaymentsList.Items.Clear();
            AddNotificationsList.Items.Clear();
        }

        private void AddAuthor_Click(object obj, RoutedEventArgs e)
        {
            if (AuthorsComboBox.SelectedItem is Authors selected && !AddedAuthorsList.Items.Contains(selected))
            {
                AddedAuthorsList.Items.Add(selected);
                AddedAuthorsList.Items.Refresh(); // Обновляем ListBox
            }
            else
            {
                MessageBox.Show("Выберите автора из списка.");
            }
        }

        private void AddAuthors_Click(object sender, RoutedEventArgs e)
        {
            using ApplicationContext context = new();
            AuthorsComboBox.ItemsSource = context.Author.ToList();
            AuthorsComboBox.Visibility = Visibility.Visible;
            AddedAuthorsList.Visibility = Visibility.Visible;
            AddAuthor.Visibility = Visibility.Visible;
        }

        private void ClosePayment_Click(object sender, RoutedEventArgs e)
        {
            AddPaymentsList.Visibility = Visibility.Collapsed;
            File.Visibility = Visibility.Collapsed;
            Payment.Visibility = Visibility.Collapsed;
            AddPayment.Visibility = Visibility.Collapsed;
            ClosePayment.Visibility = Visibility.Collapsed;
        }

        private void AddPayments_Click(object sender, RoutedEventArgs e)
        {
            AddPaymentsList.Visibility = Visibility.Visible;
            File.Visibility = Visibility.Visible;
            Payment.Visibility = Visibility.Visible;
            AddPayment.Visibility = Visibility.Visible;
            ClosePayment.Visibility = Visibility.Visible;
        }

        private void CloseNotification_Click(object sender, RoutedEventArgs e)
        {
            AddNotificationsList.Visibility = Visibility.Collapsed;
            TextNotificationName.Visibility = Visibility.Collapsed;
            NotificationName.Visibility = Visibility.Collapsed;
            TextNotificationAddressee.Visibility = Visibility.Collapsed;
            NotificationAddressee.Visibility = Visibility.Collapsed;
            TextNotificationMessage.Visibility = Visibility.Collapsed;
            NotificationMessage.Visibility = Visibility.Collapsed;
            AddNotification.Visibility = Visibility.Collapsed;
            CloseNotification.Visibility = Visibility.Collapsed;
        }

        private void AddNotifications_Click(object sender, RoutedEventArgs e)
        {
            AddNotificationsList.Visibility = Visibility.Visible;
            TextNotificationName.Visibility = Visibility.Visible;
            NotificationName.Visibility = Visibility.Visible;
            TextNotificationAddressee.Visibility = Visibility.Visible;
            NotificationAddressee.Visibility = Visibility.Visible;
            TextNotificationMessage.Visibility = Visibility.Visible;
            NotificationMessage.Visibility = Visibility.Visible;
            AddNotification.Visibility = Visibility.Visible;
            CloseNotification.Visibility = Visibility.Visible;
        }

        private void AddPayment_Click(object sender, RoutedEventArgs e)
        {
            using ApplicationContext context = new ApplicationContext();
            context.Payments.Add(new Models.Payments
            {
                File = _filePath,
            });
            context.SaveChanges();
            int Id = context.Payments.Max(b => b.IdPay);
            AddPaymentsList.Items.Add(context.Payments.Where(b => b.IdPay == Id).FirstOrDefault());
            AddPaymentsList.Items.Refresh();
        }

        private void AddNotification_Click(object sender, RoutedEventArgs e)
        {
            using ApplicationContext context = new ApplicationContext();
            context.Notification.Add(new Models.Notification
            {
                Name = NotificationName.Text,
                Addressee = NotificationAddressee.Text,
                Message = NotificationMessage.Text
            });
            context.SaveChanges();
            NotificationName.Clear();
            NotificationAddressee.Clear();
            NotificationMessage.Clear();
            int Id = context.Notification.Max(b => b.IdNotification);
            AddNotificationsList.Items.Add(context.Notification.Where(b => b.IdNotification == Id).FirstOrDefault());
            AddNotificationsList.Items.Refresh();
        }

        private void Payment_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Выберите файл";
            openFileDialog.Filter = "Все файлы (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                _filePath = openFileDialog.FileName;
                MessageBox.Show("Выбран файл: " + _filePath);
            }

        }
    }
}
