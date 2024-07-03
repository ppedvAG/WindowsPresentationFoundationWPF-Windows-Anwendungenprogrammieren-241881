using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace M000;

public class ARGBConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
        //double[] d = values.OfType<double>().ToArray();
        //byte[] b = d.Select(e => (byte) e).ToArray();

        //byte[] b = values.OfType<double>().Select(e => (byte) e).ToArray();

        byte[] b = values.Select(e => (byte) (double) e).ToArray();
		Color c = Color.FromArgb(b[0], b[1], b[2], b[3]);
		return new SolidColorBrush(c);
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
}