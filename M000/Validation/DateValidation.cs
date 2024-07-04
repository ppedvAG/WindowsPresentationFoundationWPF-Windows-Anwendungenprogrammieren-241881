using System.Globalization;
using System.Windows.Controls;

namespace M000.Validation;

public class DateValidation : ValidationRule
{
	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		DateTime dt = (DateTime)value;
		if (dt > DateTime.Now || dt < DateTime.Now.AddYears(-100))
		{
			return new ValidationResult(false, "Das Geburtsdatum ist invalide");
		}
		return ValidationResult.ValidResult;
	}
}