using M014.Model;
using M014.Util;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace M014.ViewModel;

public class MainWindowViewModel
{
	public CustomCommand DeletePersonCommand { get; set; } = new();

	public ObservableCollection<Person> Personen { get; set; } = new();

	/// <summary>
	/// Wenn der DataContext angelegt wird, wird hier ein Objekt erstellt
	/// </summary>
	public MainWindowViewModel()
    {
		string readJson = File.ReadAllText(@"..\..\..\Personen.json");
		foreach (Person p in JsonSerializer.Deserialize<List<Person>>(readJson)!)
			Personen.Add(p);

		DeletePersonCommand._execute = DeletePerson;
	}

	public void DeletePerson(object o)
	{
		Person p = (Person)o;
		Personen.Remove(p);
	}
}