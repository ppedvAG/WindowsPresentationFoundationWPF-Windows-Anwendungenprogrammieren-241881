using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Windows.Data;

namespace M000
{
	public class Test2Converter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}