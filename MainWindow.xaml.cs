using DashaD.Context;
using DashaD.Models;
using DashaD.Pages;
using System.Windows;
using System.Windows.Controls;

namespace DashaD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int IdActivEmployee = 2;

        public static Frame mainWindow = new Frame();
        public static Frame frame = new Frame();

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Патенты";
            mainWindow = Input;
            frame = MainFrame;
            this.WindowState = WindowState.Maximized;
            using ApplicationContext context = new ApplicationContext();
            Input.Navigate(new InputPage());
        }

        private void ViewPatents_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PatentsPage());
        }

        private void ViewAuthors_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AuthorsPage());
        }

        private void ViewBid_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BidPage());
        }
        private void ViewEmployee_Click(object sender, RoutedEventArgs e)
        {
            using ApplicationContext context = new ApplicationContext();
            string role = context.EmployeeData
                              .Where(e => e.IdEmployee == IdActivEmployee)
                              .Select(e => e.Role)
                              .FirstOrDefault();
            if (role == "Пользователь")
            {
                MessageBox.Show("У вас нет прав для просмотра пользователей.", "Доступ запрещён", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            MainFrame.Navigate(new EmployeePage());
        }
        public static bool CheckEmployee()
        {
            using ApplicationContext context = new ApplicationContext();
            string role = context.EmployeeData.Where(e => e.IdEmployee == IdActivEmployee).Select(e => e.Role).FirstOrDefault();
            if (role == "Администратор")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void SettingsPatent_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                MainWindow.IdActivEmployee = 0;

                MainWindow.mainWindow.Navigate(new InputPage());

                MainWindow.frame.Content = null;
                while (MainWindow.frame.NavigationService.CanGoBack)
                {
                    MainWindow.frame.NavigationService.RemoveBackEntry();
                }
            }
        }


    }
}
