using Dosug.Infrastructure;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Dosug.View
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        private string? _password;

        public AuthPage() => InitializeComponent();

        private void OnLoginBtnClick(object sender, RoutedEventArgs e)
        {
            var users = Helper.Database.User.ToList();
            Helper.SafeInvoke(() => {
                Helper.LoginUser = Helper.Database.User.Where(x => x.Login == LoginField.Text
                 && x.Password == _password).FirstOrDefault();
            });

            if (Helper.LoginUser != null)
            {
                Helper.MainWindow.RoleTitle.Content = $"Вы зашли как: {Helper.LoginUser.Role.Name}";
                Helper.NavFrame.Navigate(new EventPage());
            }
            else
            {
                MessageBox.Show("Подьзователь не найден! Проверьте корректность введенных данных!",
                    "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                _password = passwordBox.Password;
            }
        }

        private void OnGuestLoginBtnClick(object sender, RoutedEventArgs e)
        {
            Helper.MainWindow.RoleTitle.Content = "Вы зашли как: гость";
            Helper.NavFrame.Navigate(new EventPage());
        }
    }
}

