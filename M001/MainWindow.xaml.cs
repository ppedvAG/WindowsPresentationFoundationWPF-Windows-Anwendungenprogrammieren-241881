using System.IO;
using System.Windows;

namespace M000;

public partial class MainWindow : Window
{
	public List<Setting> SettingsFile { get; set; } = [new Setting() { Name = "Keine Einstellungen" }];

	public MainWindow()
	{
		SettingsFile = File.ReadAllLines("Settings.txt")
			.Select(e => new Setting() { Name = e.Split("=")[0], Value = e.Split("=")[1] })
			.ToList();
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