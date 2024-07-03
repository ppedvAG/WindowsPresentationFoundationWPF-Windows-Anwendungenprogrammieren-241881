using System.IO;
using System.Windows;

namespace M000;

public partial class MainWindow : Window
{
	public List<Setting> SettingsFile { get; set; } = [new Setting() { Name = "Keine Einstellungen" }];

	public MainWindow()
	{
		SettingsFile = File.ReadAllLines("Settings.txt")
			.Select<string, Setting>(e =>
			{
				string[] parts = e.Split("=");
				if (bool.TryParse(parts[1], out bool result))
					return new BooleanSetting() { Name = parts[0], Value = result };
				else
					return new TextSetting() { Name = parts[0], Value = parts[1] };
			}).ToList();
		InitializeComponent();
	}
}

public class Setting
{
	public string Name { get; set; }

	public object Value { get; set; }
}

public class TextSetting : Setting { }

public class BooleanSetting : Setting { }