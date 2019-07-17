using System.Windows;

namespace Musicbar.Extensions
{
    public class ButtonImageProperty : DependencyObject
    {
        public static readonly DependencyProperty ImagePathProperty = DependencyProperty.RegisterAttached(
            "ImagePath", typeof(string), typeof(ButtonImageProperty), new PropertyMetadata(""));

        public static void SetImagePath(DependencyObject target, string value)
        {
            target.SetValue(ImagePathProperty, value);
        }

        public static string GetImagePath(DependencyObject target)
        {
            return (string) target.GetValue(ImagePathProperty);
        }
    }
}