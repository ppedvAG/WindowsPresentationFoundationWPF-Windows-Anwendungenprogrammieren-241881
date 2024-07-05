using System.Globalization;
using System.Windows.Data;

namespace M012;

public class StringConcatConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		IEnumerable<string> strings = value as IEnumerable<string>;
		return string.Join(", ", strings);
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}