using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace M012;

public partial class MainWindow : Window
{
	public ObservableCollection<Person> Personen { get; set; } = new();

	public MainWindow()
	{
		InitializeComponent();
		string readJson = File.ReadAllText(@"..\..\..\Personen.json");
		//foreach (Person p in JsonSerializer.Deserialize<List<Person>>(readJson)!)
		//	Personen.Add(p);
		Personen.AddRange(JsonSerializer.Deserialize<List<Person>>(readJson)!);
		//ExtensionMethods.AddRange(Personen, JsonSerializer.Deserialize<List<Person>>(readJson)!); //Wird vom Compiler generiert
		
		//Unser Code vs. Compiler Code
		Personen.Where(e => e.Alter > 30);
		Enumerable.Where(Personen, e => e.Alter > 30);
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Button b = (sender as Button)!;
		Person p = (b.DataContext as Person)!;
		//Person p2 = b.Tag as Person;
		Personen.Remove(p);
	}
}

///////////////////////////////////////////////////////////////////////////////

[DebuggerDisplay("Person - ID: {ID}, Vorname: {Vorname}, Nachname: {Nachname}, GebDat: {Geburtsdatum.ToString(\"yyyy.MM.dd\")}, Alter: {Alter}, " +
	"Jobtitel: {Job.Titel}, Gehalt: {Job.Gehalt}, Einstellungsdatum: {Job.Einstellungsdatum.ToString(\"yyyy.MM.dd\")}")]
public record Person(int ID, string Vorname, string Nachname, DateTime Geburtsdatum, int Alter, Beruf Job, List<string> Hobbies);

public record Beruf(string Titel, int Gehalt, DateTime Einstellungsdatum);

///////////////////////////////////////////////////////////////////////////////