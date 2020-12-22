using System.Windows;
using System.Windows.Controls;

namespace Eumel.EmailCategorizer.Core.Ui
{
    public static class WpfExtensions
    {
        public static bool? ShowModel(this UserControl control, string title)
        {
            var window = new Window
            {
                Title = title,
                Content = control,
                Width = control.Width,
                Height = control.Height
            };

            return window.ShowDialog();
        }
    }
}