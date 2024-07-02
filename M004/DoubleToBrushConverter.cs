using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace M004;

public class DoubleToBrushConverter : IValueConverter
{
	//Quelle -> Ziel
	//Slider -> TextBlock
	//value: double vom Slider
	//return: Farbe -> Brush
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		//Immer wenn das Binding ausgeführt wird, wird dieses Stück Code ausgeführt
		double d = (double)value;
		byte b = (byte)d;
		SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(255, b, b, b));
		return brush;
	}

	//Ziel -> Quelle
	//TextBlock -> Slider
	//ConvertBack kann hier ignoriert werden, nachdem der Background von TextBlock sich ohne den Slider nicht verändern kann
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}