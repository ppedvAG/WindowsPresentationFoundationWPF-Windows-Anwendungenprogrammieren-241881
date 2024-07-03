using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace M007;

public class AlignmentConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return (HorizontalAlignment) value switch
		{
			HorizontalAlignment.Left => TextAlignment.Left,
			HorizontalAlignment.Right => TextAlignment.Right,
			HorizontalAlignment.Center => TextAlignment.Center,
			HorizontalAlignment.Stretch => TextAlignment.Justify
		};
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return (TextAlignment) value switch
		{
			TextAlignment.Left => HorizontalAlignment.Left,
			TextAlignment.Right => HorizontalAlignment.Right,
			TextAlignment.Center => HorizontalAlignment.Center,
			TextAlignment.Justify => HorizontalAlignment.Stretch
		};
	}
}