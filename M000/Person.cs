using System.ComponentModel;
using System.Windows.Media;

namespace M000;

public class Person : INotifyPropertyChanged
{
	private string vorname;

	public string Vorname
	{
		get => vorname;
		set
		{
			vorname = value;
			Notify(nameof(Vorname));
		}
	}

	private string nachname;

	public string Nachname
	{
		get => nachname;
		set
		{
			nachname = value;
			Notify(nameof(Nachname));
		}
	}

	private DateTime gebDat;

	public DateTime GebDat
	{
		get => gebDat;
		set
		{
			gebDat = value;
			Notify(nameof(GebDat));
		}
	}

	private bool verheiratet;

	public bool Verheiratet
	{
		get => verheiratet;
		set
		{
			verheiratet = value;
			Notify(nameof(Verheiratet));
		}
	}

	private Color lieblingsfarbe;

	public Color Lieblingsfarbe
	{
		get => lieblingsfarbe;
		set
		{
			lieblingsfarbe = value;
			Notify(nameof(Lieblingsfarbe));
		}
	}

	private Geschlecht geschlecht;

	public Geschlecht Geschlecht
	{
		get => geschlecht;
		set
		{
			geschlecht = value;
			Notify(nameof(Geschlecht));
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	public void Notify(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}