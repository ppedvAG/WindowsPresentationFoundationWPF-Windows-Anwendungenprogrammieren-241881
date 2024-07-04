using System.Windows.Markup;

namespace M008;

public class EnumExtension : MarkupExtension
{
	public Type EnumType { get; set; }

	/// <summary>
	/// ProvideValue
	/// Gibt den Wert an die GUI weiter (wird beim entsprechenden Property eingetragen)
	/// 
	/// Kann auch fixe Werte an die GUI weitergeben
	/// </summary>
	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		if (!EnumType.IsEnum)
			throw new ArgumentException("Der gegebene Typ ist kein EnumTyp");

		return Enum.GetValues(EnumType);
	}
}