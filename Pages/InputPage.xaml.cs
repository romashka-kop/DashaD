using DashaD.Context;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace DashaD
{
    /// <summary>
    /// Логика взаимодействия для InputPage.xaml
    /// </summary>
    public partial class InputPage : Page
    {
        public InputPage()
        {
            InitializeComponent();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void Input_Click(object sender, RoutedEventArgs e)
        {
            string email = Email.Text.Trim();
            string password = PasswordBox.Password.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите email и пароль.");
                return;
            }
            using var context = new ApplicationContext();

            var employee = context.EmployeeData.FirstOrDefault(e => e.Email == email);

            if (employee == null)
            {
                MessageBox.Show("Пользователь не найден.");
                return;
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, employee.Password);

            if (!isPasswordValid)
            {
                MessageBox.Show("Неверный пароль.");
                return;
            }

            MainWindow.IdActivEmployee = employee.IdEmployee;
            Page.Visibility = Visibility.Collapsed;
        }
    }
}
