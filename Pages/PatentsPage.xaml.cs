using DashaD.Context;
using DashaD.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using System.Windows.Controls;

namespace DashaD
{
    /// <summary>
    /// Логика взаимодействия для PatentsPage.xaml
    /// </summary>
    public partial class PatentsPage : Page
    {
        private bool _isAdm = false;
        public PatentsPage()
        {
            InitializeComponent();
            _isAdm = MainWindow.CheckEmployee();
            AddPatent.IsEnabled = _isAdm;
            View(PatentsView);
        }

        public static void View(DataGrid patentView)
        {
            using ApplicationContext context = new ApplicationContext();
            var patentsWithAuthors = context.Patent
                .Select(p => new
                {
                p.IdPatent,
                p.PatentName,
                p.Number,
                Authors = string.Join(", ", context.PatentAuthors
                .Where(pa => pa.IdPatent == p.IdPatent)
                .Join(context.Author,
                  pa => pa.IdAuthor,
                  a => a.IdAuthor,
                  (pa, a) => a.FullName))
                }).ToList();

            patentView.ItemsSource = patentsWithAuthors;

        }

        private void AddPatent_Click(object sender, RoutedEventArgs e)
        {
            var newAddPatentWindow = new AddPatentWindow();
            newAddPatentWindow.Owner = Window.GetWindow(this);
            newAddPatentWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            if (newAddPatentWindow.ShowDialog() == true)
            {
                View(PatentsView);
            }
        }

        private void ViewPatents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isAdm)
            {
                using ApplicationContext context = new ApplicationContext();
                var selectedItem = PatentsView.SelectedItem as dynamic;
                var patent = (Patents)PatentsView.SelectedItem;

                if (selectedItem != null)
                {
                    int patentRet = context.Patent.Where(p => p.IdPatent == patent.IdPatent).Select(p => p.IdPatent).FirstOrDefault();
                    var newPatentWindow = new PatentWindow(patentRet, PatentsView, _isAdm);
                    newPatentWindow.Owner = Window.GetWindow(this);
                    newPatentWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    if (newPatentWindow.ShowDialog() == true)
                    {
                        View(PatentsView);
                    }
                }
            }

        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            using ApplicationContext context = new ApplicationContext();
            PatentsView.ItemsSource = context.Patent.Where(p => p.PatentName.Contains(Search.Text)
            || p.Number.ToString().Contains(Search.Text)
            || p.DatePriority.ToString().Contains(Search.Text)
            || p.DateRegistration.ToString().Contains(Search.Text)
            || p.DateFinal.ToString().Contains(Search.Text))
                .Select(p => new { p.IdPatent, p.PatentName, p.Number, p.DatePriority, p.DateRegistration, p.DateFinal }).ToList();
            if (Search.Text.IsNullOrEmpty())
            {
                View(PatentsView);
            }
        }

        private void BackPatent_Click(object sender, RoutedEventArgs e)
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
    }
}
