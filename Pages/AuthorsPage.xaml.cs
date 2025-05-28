using DashaD.Context;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Controls;

namespace DashaD
{
    /// <summary>
    /// Логика взаимодействия для AuthorsPage.xaml
    /// </summary>
    public partial class AuthorsPage : Page
    {
        private bool _isAdm = false;
        public AuthorsPage()
        {
            InitializeComponent();
            _isAdm = MainWindow.CheckEmployee();
            AddAuthor.IsEnabled = _isAdm;
            View(AuthorsView);
        }

        public static void View(DataGrid authorsView)
        {
            using ApplicationContext context = new ApplicationContext();
            var authors = context.Author.Select(a => new { a.IdAuthor, a.FullName }).ToList();

            authorsView.ItemsSource = authors;
        }

        private void AddAuthor_Click(object sender, RoutedEventArgs e)
        {
            var newAddAuthorWindow = new AddAuthorWindow(AuthorsView);
            newAddAuthorWindow.Owner = Window.GetWindow(this);
            newAddAuthorWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            if (newAddAuthorWindow.ShowDialog() == true)
            {
                View(AuthorsView);
            }
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            using ApplicationContext context = new ApplicationContext();
            AuthorsView.ItemsSource = context.Author.Where(a => a.FullName.Contains(Search.Text))
                .Select(a => new { a.IdAuthor, a.FullName }).ToList();
            if (Search.Text.IsNullOrEmpty())
            {
                View(AuthorsView);
            }
        }

        private void BackAuthor_Click(object sender, RoutedEventArgs e)
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

        private void AuthorsView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AuthorsView.SelectedItem is not null)
            {
                dynamic selectedItem = AuthorsView.SelectedItem;
                int firstColumnValue = selectedItem.IdAuthor;

                var newAuthorWindow = new AuthorWindow(firstColumnValue, AuthorsView, _isAdm);
                newAuthorWindow.Owner = Window.GetWindow(this);
                newAuthorWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                if (newAuthorWindow.ShowDialog() == true)
                {
                    View(AuthorsView);
                }
            }
        }
    }
}
