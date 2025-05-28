using DashaD.Context;
using DashaD.Models;
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

namespace DashaD
{
    /// <summary>
    /// Логика взаимодействия для AuthorWindow.xaml
    /// </summary>
    public partial class AuthorWindow : Window
    {
        private int _authorId;
        private DataGrid _grid;

        public AuthorWindow(int idAuthor, DataGrid data, bool isAdm)
        {
            MessageBox.Show(isAdm.ToString());
            _authorId = idAuthor;
            _grid = data;
            InitializeComponent();
            AddAuthor.IsEnabled = isAdm;
            SetDataOnControlls();
        }

        private void SetDataOnControlls()
        {
            using ApplicationContext context = new();
            Authors author = context.Author.First(a => a.IdAuthor == _authorId);
            AuthorSurname.Text = author.Surname;
            AuthorName.Text = author.Name;
            AuthorPatronymic.Text = author.Patronymic;
            AuthorAddress.Text = author.Address;
            AuthorPhoneNumber.Text = author.NumberPhone;
        }

        private void AddAuthor_Click(object sender, RoutedEventArgs e)
        {
            using ApplicationContext context = new();
            Authors author = context.Author.First(a => a.IdAuthor == _authorId);
            author.Surname = AuthorSurname.Text;
            author.Name = AuthorName.Text;
            author.Patronymic = AuthorPatronymic.Text;
            author.Address = AuthorAddress.Text;
            author.NumberPhone = AuthorPhoneNumber.Text;

            context.SaveChanges();
            AuthorsPage.View(_grid);
        }
    }
}
