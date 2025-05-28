using System.Windows;

namespace DashaD
{
    public partial class AdminCodeWindow : Window
    {
        public bool IsCorrect { get; private set; } = false;
        private const string AdminCode = "AdminCode#"; // Твой секретный код

        public AdminCodeWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (CodeInput.Password == AdminCode)
            {
                IsCorrect = true;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Неверный код!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                DialogResult = false;
            }
        }
    }
}