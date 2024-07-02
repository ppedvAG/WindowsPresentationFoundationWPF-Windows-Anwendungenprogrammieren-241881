using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace M004;

public class FourValueToMarginConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		double[] d = values.OfType<double>().ToArray();
		Thickness t = new Thickness(d[0], d[1], d[2], d[3]);
		return t;
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
}