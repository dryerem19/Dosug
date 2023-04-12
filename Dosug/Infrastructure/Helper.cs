using Dosug.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Dosug.Infrastructure
{
    public static class Helper
    {
        public static ApplicationDatabase Database { get; set; }
        public static Frame NavFrame { get; set; }
        public static MainWindow MainWindow { get; set; }
        public static User? LoginUser { get; set; }

        public static byte[]? LoadImage(string filepath)
        {
            if (string.IsNullOrEmpty(filepath))
            {
                return null;
            }

            return File.ReadAllBytes(filepath);
        }

        public static void ImportImageToDb()
        {
            SafeInvoke(() =>
            {
                foreach (var file in Directory.GetFiles(@"C:\Users\Denis\Desktop\Мероприятия_import"))
                {
                    var filaname = Path.GetFileNameWithoutExtension(file);
                    foreach (var someEvent in Database.Event)
                    {
                        if (someEvent.Name == filaname)
                        {
                            var image = LoadImage(file);
                            if (image != null)
                            {
                                someEvent.Image = image;
                            }
                        }
                    }
                }
            });

            SaveDb();
        }

        public static void SaveDb()
        {
            try
            {
                Database.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Не удалось сохранить БД: {ex.Message}",
                    "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void SafeInvoke(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка во время выполнения: {ex.Message}", 
                    "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
