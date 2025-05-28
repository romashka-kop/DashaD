using DashaD.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using DashaD.Models;

namespace DashaD
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()]).{8,}$";

            return Regex.IsMatch(password, pattern);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            string selectedRole = (Role.SelectedItem as ComboBoxItem)?.Content?.ToString();

            string surname = Surname.Text;
            string name = Name.Text;
            string patronymic = Patronymic.Text;
            string department = Department.Text;
            string email = Email.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            

            if (string.IsNullOrWhiteSpace(surname) ||
                string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(patronymic) ||
                string.IsNullOrWhiteSpace(department) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Все поля должны быть заполнены.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            if (selectedRole == "Адм")
            {
                var codeWindow = new AdminCodeWindow();
                codeWindow.Owner = Window.GetWindow(this);
                bool? result = codeWindow.ShowDialog();

                if (result != true || !codeWindow.IsCorrect)
                {
                    MessageBox.Show("Регистрация отменена: неверный код администратора", "Ошибка!", MessageBoxButton.OK);
                    return;
                }
            }
            try
            {
                using ApplicationContext context = new ApplicationContext();
                context.EmployeeData.Add(new Models.EmployeeData
                {
                    Surname = surname,
                    Name = name,
                    Patronymic = patronymic,
                    Department = department,
                    Email = email,
                    Password = BCrypt.Net.BCrypt.HashPassword(password),
                    Role = Role.SelectedIndex,
                });
                context.SaveChanges();
                MessageBox.Show("Регистрация прошла успешно.");
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException?.Message;
                MessageBox.Show($"Ошибка при сохранении: {innerException}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Введите корректный адрес электронной почты.");
                return;
            }

            if (!IsValidPassword(password))
            {
                MessageBox.Show("Пароль должен содержать:\n" + "- Не менее 8 символов\n" + "- Заглавные и строчные буквы\n" + "- Цифры\n" + "- Специальные символы (!@#$%^&*())", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            NavigationService.Navigate(new InputPage());
        }
    }
}
