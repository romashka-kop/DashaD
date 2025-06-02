using DashaD.Context;
using DashaD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Tokens;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DashaD.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        private int _selectIdEmployee;
        public EmployeePage()
        {
            InitializeComponent();
            View(EmployeeView);
        }

        public static void View(DataGrid employeeView)
        {
            using ApplicationContext context = new ApplicationContext();
            var employee = context.EmployeeData
                .Select(e => new
                { e.IdEmployee, e.Role, e.FullName }).ToList();

            employeeView.ItemsSource = employee;
        }

        private void RemoveEmployee_Click(object sender, RoutedEventArgs e)
        {
            using ApplicationContext context = new();
            dynamic item = EmployeeView.SelectedItem;
            if(item is null)
            {
                return;
            }
            int id = item.IdEmployee;

            EmployeeData employee = context.EmployeeData.Where(e => e.IdEmployee == id).First();

            // Теперь можно работать с объектом employee
            if (employee.Role == "Администратор")
            {
                MessageBox.Show("Удаление администратора запрещено.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (employee.Role == "Пользователь")
            {
                context.EmployeeData.Remove(employee);
                context.SaveChanges();
                View(EmployeeView);
            }
        }

        private void BackEmployee_Click(object sender, RoutedEventArgs e)
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

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            using ApplicationContext context = new ApplicationContext();
            EmployeeView.ItemsSource = context.EmployeeData.Where(e => e.FullName.Contains(Search.Text)
                || e.Role.Contains(Search.Text))
                .Select(e => new { e.IdEmployee, e.FullName }).ToList();
            if (Search.Text.IsNullOrEmpty())
            {
                View(EmployeeView);
            }
        }
    }
}
