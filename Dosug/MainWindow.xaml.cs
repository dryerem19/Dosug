using Dosug.Infrastructure;
using Dosug.View;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Dosug
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavFrame.Navigate(new AuthPage());
            Helper.NavFrame = NavFrame;
            Helper.MainWindow = this;

            //Helper.ImportImageToDb();
        }

        private void OnBackBtnClick(object sender, RoutedEventArgs e)
        {
            Helper.NavFrame.GoBack();
        }

        private void OnExitBtnClick(object sender, RoutedEventArgs e)
        {
            if (MessageBoxResult.Yes ==  MessageBox.Show("Вы уверены, что хотите выйти?", 
                "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question))
            {
                Application.Current.Shutdown();
            }
        }

        private void OnFrameRendered(object sender, EventArgs e)
        {
            if (NavFrame.CanGoBack)
            {
                BackBtn.Visibility = Visibility.Visible;
                ExitBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                BackBtn.Visibility = Visibility.Collapsed;
                ExitBtn.Visibility = Visibility.Visible;
            }
        }

        private void OnFrameNavigated(object sender, NavigationEventArgs e)
        {
            if (e.Content is Page page)
            {
                PageTitle.Content = page.Title;
            }
        }
    }
}
