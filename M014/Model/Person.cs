namespace M014.Model;

public class Person
{
	public int ID { get; set/*init*/; }

	public string Vorname { get; set/*init*/; }

	public string Nachname { get; set/*init*/; }

	public DateTime Geburtsdatum { get; set/*init*/; }

	public int Alter { get; set/*init*/; }

	public Beruf Job { get; set/*init*/; }

	public List<string> Hobbies { get; set/*init*/; }

	public Person(int ID, string Vorname, string Nachname, DateTime Geburtsdatum, int Alter, Beruf Job, List<string> Hobbies)
	{
		this.ID = ID;
		this.Vorname = Vorname;
		this.Nachname = Nachname;
		this.Geburtsdatum = Geburtsdatum;
		this.Alter = Alter;
		this.Job = Job;
		this.Hobbies = Hobbies;
	}
}