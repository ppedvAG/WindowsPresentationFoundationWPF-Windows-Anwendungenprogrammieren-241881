using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace M004;

public class ScoreToColorConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		double d = (double)value;
		Color c;
		if (d < 50)
			c = Colors.Red;
		else if (d < 60)
			c = Colors.Orange;
		else if (d < 70)
			c = Colors.Yellow;
		else if (d < 80)
			c = Colors.LightGreen;
		else if (d < 90)
			c = Colors.Green;
		else
			c = Colors.DarkGreen;
		return new SolidColorBrush(c);
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}