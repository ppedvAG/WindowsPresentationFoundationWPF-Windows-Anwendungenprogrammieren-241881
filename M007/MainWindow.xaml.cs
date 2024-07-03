using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M007;

public partial class MainWindow : Window
{
	public ObservableCollection<Person> Personen { get; set; } = new();

	public ObservableCollection<int> Zahlen { get; set; } = new(Enumerable.Range(1, 100));

	public ObservableCollection<Setting> SettingsFile { get; set; } = new();

	public MainWindow()
	{
		InitializeComponent();

		string readJson = File.ReadAllText(@"..\..\..\Personen.json");
		foreach (Person p in JsonSerializer.Deserialize<List<Person>>(readJson).Take(30))
			Personen.Add(p);

		var x = File.ReadAllLines("Settings.txt")
			.Select<string, Setting>(e =>
			{
				string[] parts = e.Split("=");
				if (bool.TryParse(parts[1], out bool result))
					return new BooleanSetting() { Name = parts[0], Value = result };
				else if (double.TryParse(parts[1], out double resutl))
					return new IntegerSetting() { Name = parts[0], Value = result };
				else
					return new TextSetting() { Name = parts[0], Value = parts[1] };
			});

		foreach (var setting in x)
			SettingsFile.Add(setting);
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		MessageBox.Show("Hallo");
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		Person toDelete = (sender as FrameworkElement).DataContext as Person;
		Personen.Remove(toDelete);
	}
}


public class Setting
{
	public string Name { get; set; }

	public object Value { get; set; }
}

public class TextSetting : Setting { }

public class BooleanSetting : Setting { }

public class IntegerSetting : Setting { }

///////////////////////////////////////////////////////////////////////////////

[DebuggerDisplay("Person - ID: {ID}, Vorname: {Vorname}, Nachname: {Nachname}, GebDat: {Geburtsdatum.ToString(\"yyyy.MM.dd\")}, Alter: {Alter}, " +
	"Jobtitel: {Job.Titel}, Gehalt: {Job.Gehalt}, Einstellungsdatum: {Job.Einstellungsdatum.ToString(\"yyyy.MM.dd\")}")]
public record Person(int ID, string Vorname, string Nachname, DateTime Geburtsdatum, int Alter, Beruf Job, List<string> Hobbies);

public record Beruf(string Titel, int Gehalt, DateTime Einstellungsdatum);

///////////////////////////////////////////////////////////////////////////////