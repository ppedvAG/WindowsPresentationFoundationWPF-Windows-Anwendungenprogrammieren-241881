using M000.Model;
using M000.Util;
using System.Windows;

namespace M000.ViewModel;

public class PersonDialogViewModel
{
	public Person person { get; set; } = new();

	public CustomCommand OkCommand { get; set; } = new();

	public PersonDialogViewModel()
    {
		OkCommand._execute = OkButton;
    }

	public void OkButton(object o)
	{
		MessageBox.Show($"{person.Vorname}\n{person.Nachname}\n{person.GebDat}\n{person.Verheiratet}\n{person.Lieblingsfarbe}\n{person.Geschlecht}\n{person.AnzahlKinder}");
	}
}