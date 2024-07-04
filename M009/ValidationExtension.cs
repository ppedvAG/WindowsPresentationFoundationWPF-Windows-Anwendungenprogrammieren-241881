using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace M009;

public class ValidationExtension : MarkupExtension
{
	//Das Binding, welches ins Backend gelegt wurde
	public Binding Binding { get; set; }

	//Eine oder mehrere Regeln, welche hinzugefügt werden sollen
	public ValidationRule Rule { get; set; }

	public ValidationRuleCollection Rules { get; set; } = new();

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		if (Rule != null)
			Binding.ValidationRules.Add(Rule);

		foreach (ValidationRule rule in Rules)
		{
			if (rule != null)
			{
				Binding.ValidationRules.Add(rule);
			}
		}

		//Führe das Binding normal weiter aus
		return Binding.ProvideValue(serviceProvider);
	}
}