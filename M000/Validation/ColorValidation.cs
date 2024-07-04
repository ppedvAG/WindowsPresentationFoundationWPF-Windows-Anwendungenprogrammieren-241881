using System.Globalization;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media;

namespace M000.Validation;

public class ColorValidation : ValidationRule
{
	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		if (value is not string)
		{
			Color c = (Color)value;
			if (c == Color.FromArgb(0, 0, 0, 0))
				return new ValidationResult(false, "Die Farbe muss ausgewählt sein");
		}
		return ValidationResult.ValidResult;
	}
}