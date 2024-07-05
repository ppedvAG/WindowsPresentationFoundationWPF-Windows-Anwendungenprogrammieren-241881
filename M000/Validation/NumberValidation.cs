using System.Globalization;
using System.Windows.Controls;

namespace M000.Validation;

public class NumberValidation : ValidationRule
{
	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		int x = (int) value;
		if (x < 0)
			return new ValidationResult(false, "Die Zahl darf nicht negativ sein!");
		return ValidationResult.ValidResult;
	}
}