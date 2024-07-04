using System.Globalization;
using System.Windows.Data;

namespace M000.Converter;

public class GenderConverter : IValueConverter
{
    //Objekt -> UI
    //Laden einer vorgegebenen Person
    //value: Geschlecht vom Objekt
    //parameter: Der Geschlechtszustand des RadioButtons der geprüft werden soll
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (Geschlecht)value == (Geschlecht)parameter;
    }

    //UI -> Objekt
    //Verwendung eines RadioButtons des Benutzers
    //value: bool
    //parameter: Geschlecht des entsprechenden RadioButtons
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (bool)value == true ? (Geschlecht)parameter : Binding.DoNothing;
    }
}