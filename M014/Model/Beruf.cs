namespace M014.Model;

public class Beruf
{
	public string Titel { get; set/*init*/; }

	public int Gehalt { get; set/*init*/; }

	public DateTime Einstellungsdatum { get; set/*init*/; }

	public Beruf(string Titel, int Gehalt, DateTime Einstellungsdatum)
	{
		this.Titel = Titel;
		this.Gehalt = Gehalt;
		this.Einstellungsdatum = Einstellungsdatum;
	}
}