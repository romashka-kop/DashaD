using System.Configuration;
using System.Data;
using System.Windows;

namespace DashaD
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void LoadTheme(string themeName)
        {
            ResourceDictionary dict = new ResourceDictionary();

            switch (themeName)
            {
                case "Dark":
                    dict.Source = new Uri("Themes/DarkTheme.xaml", UriKind.Relative);
                    break;
                default:
                    dict.Source = new Uri("Themes/LightTheme.xaml", UriKind.Relative);
                    break;
            }

            this.Resources.MergedDictionaries.Clear();
            this.Resources.MergedDictionaries.Add(dict);
        }
    }
}
