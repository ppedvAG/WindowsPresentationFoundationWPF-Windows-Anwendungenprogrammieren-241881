using System.Windows.Data;
using System.Windows.Markup;

namespace M008;

public class ConverterExtension : MarkupExtension
{
	public Type ConverterType { get; set; }

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		if (ConverterType.GetInterface(nameof(IValueConverter)) == null)
			throw new ArgumentException("Der gegebene Typ hat nicht das IValueConverter Interface");

		return Activator.CreateInstance(ConverterType);
	}
}