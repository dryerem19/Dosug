using Dosug.Infrastructure;
using System;
using System.Windows;

namespace Dosug
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            try
            {
                Helper.Database = new ApplicationDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошиба подключения к базе: {ex.Message}", 
                    "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                Current.Shutdown();
            }
        }
    }
}
