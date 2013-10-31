namespace TriviaGame.Converters
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool? boxedBool = value as bool?;

            bool boolValue = (boxedBool != null && boxedBool == true);

            if (boolValue)
            {
                return Visibility.Collapsed;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var visibility = value as Visibility?;

            return (visibility != null && visibility == Visibility.Collapsed);
        }
    }
}