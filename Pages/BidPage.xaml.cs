using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DashaD.Context;
using Microsoft.IdentityModel.Tokens;

namespace DashaD
{
    /// <summary>
    /// Логика взаимодействия для BidPage.xaml
    /// </summary>
    /// 
    public partial class BidPage : Page
    {
        private int _selectIdBid;
        private bool _isAdm = false;
        public BidPage()
        {
            InitializeComponent();
            _isAdm = MainWindow.CheckEmployee();

            RemoveBid.IsEnabled = _isAdm;
            View(BidView);
        }

        public static void View(DataGrid bidView)
        {
            using ApplicationContext context = new ApplicationContext();
            var bid = context.Bids.Select(b => new { b.IdBid,b.BidNumber, b.DateBid }).ToList();

            bidView.ItemsSource = bid;
        }

        private void AddBid_Click(object sender, RoutedEventArgs e)
        {
            var newAddBidWindow = new AddBidWindow(BidView);
            newAddBidWindow.Owner = Window.GetWindow(this);
            newAddBidWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            if (newAddBidWindow.ShowDialog() == true)
            {
                View(BidView);
            }
        }

        private void RemoveBid_Click(object sender, RoutedEventArgs e)
        {
            using ApplicationContext context = new();
            var bid = context.Bids.First(b => b.IdBid == _selectIdBid);
            context.Bids.Remove(bid);
            context.SaveChanges();
            View(BidView);
        }

        private void BackBid_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Нет предыдущей страницы.");
            }
        }

        private void BidView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BidView.SelectedItem is not null)
            {
                dynamic selectedItem = BidView.SelectedItem;
                _selectIdBid = selectedItem.IdBid;

                var newAuthorWindow = new BidWindow(_selectIdBid, BidView);
                newAuthorWindow.Owner = Window.GetWindow(this);
                newAuthorWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                if (newAuthorWindow.ShowDialog() == true)
                {
                    View(BidView);
                }
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            using ApplicationContext context = new ApplicationContext();
            BidView.ItemsSource = context.Bids.Where(b => b.BidNumber == long.Parse(Search.Text))
                .Select(b => new { b.IdBid, b.BidNumber }).ToList();
            if (Search.Text.IsNullOrEmpty())
            {
                View(BidView);
            }
        }
    }
}
