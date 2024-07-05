using System.Windows;

namespace M000;

public partial class PersonenDialog : Window
{
	public Person person { get; set; } = new();

	//public Geschlecht[] Geschlechter { get; set; } = Enum.GetValues<Geschlecht>();

	public PersonenDialog()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		MessageBox.Show($"{person.Vorname}\n{person.Nachname}\n{person.GebDat}\n{person.Verheiratet}\n{person.Lieblingsfarbe}\n{person.Geschlecht}\n{person.AnzahlKinder}");
	}
}