using System.Globalization;
using System.Windows.Controls;

namespace M000.Validation;

public class LengthValidation : ValidationRule
{
  //  public LengthValidation()
  //  {
		//ValidatesOnTargetUpdated = true;
  //  }

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		string eingabe = value as string;
		if (eingabe != null)
			if (eingabe.Length >= 3 && eingabe.Length <= 15)
				return ValidationResult.ValidResult;

		return new ValidationResult(false, "Die Eingabe muss zwischen 3 und 15 Zeichen haben");
	}
}