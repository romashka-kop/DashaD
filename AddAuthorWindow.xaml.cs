using DashaD.Context;
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
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace DashaD
{
    /// <summary>
    /// Логика взаимодействия для AddAuthorWindow.xaml
    /// </summary>
    public partial class AddAuthorWindow : Window
    {
        private DataGrid _grid; 
        public AddAuthorWindow(DataGrid grid)
        {
            InitializeComponent();
            _grid = grid;
        }

        public bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;
            
            string pattern = @"^(\+7|8)?\s?\(?\d{3}\)?[\s-]?\d{3}[\s-]?\d{2}[\s-]?\d{2}$";

            return Regex.IsMatch(phone, pattern);
        }

        public bool IsValidAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return false;
            
            string pattern = @"^[\w\s\.,\-\/]+$";

            return Regex.IsMatch(address, pattern);
        }


        private void AddAuthor_Click(object sender, RoutedEventArgs e)
        {
            string phone = AuthorPhoneNumber.Text;
            string address = AuthorAddress.Text;

            if (!IsValidPhoneNumber(phone))
            {
                MessageBox.Show("Неверный формат номера телефона.", "Ошибка", MessageBoxButton.OK);
                return;
            }

            if (!IsValidAddress(address))
            {
                MessageBox.Show("Неверный формат адреса.", "Ошибка", MessageBoxButton.OK);
                return;
            }

            using ApplicationContext context = new ApplicationContext();
            context.Author.Add(new Models.Authors
            {
                Surname = AuthorSurname.Text,
                Name = AuthorName.Text,
                Patronymic = AuthorPatronymic.Text,
                Address = AuthorAddress.Text,
                NumberPhone = AuthorPhoneNumber.Text,
            });
            context.SaveChanges();
            ClearTextBoxes();
            AuthorsPage.View(_grid);
        }

        private void ClearTextBoxes()
        {
            AuthorSurname.Clear();
            AuthorName.Clear();
            AuthorPatronymic.Clear();
            AuthorAddress.Clear();
            AuthorPhoneNumber.Clear();
        }
    }
}
