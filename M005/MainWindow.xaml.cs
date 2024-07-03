using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;

namespace M005;

public partial class MainWindow : Window, INotifyPropertyChanged
{
	public string Text { get; set; } = "Hallo Welt";

	#region INotifyPropertyChanged
	private int zaehler = 0;

	public int Zaehler
	{
		get => zaehler;
		set
		{
			zaehler = value;
			Notify(nameof(Zaehler));
			//Notify(nameof(Zaehler), nameof(zaehler), value); //Hier kann Notify direkt implementiert werden
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	public void Notify(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

	//public void Notify([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

	//public void Notify(string propertyName, string fieldName, object value)
	//{
	//	//GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this, value);
	//	PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	//}
	#endregion

	/// <summary>
	/// BindableProperty
	/// Wrapper für INotifyPropertyChanged um für ein einzelnes Feld nicht dieses Interface implementieren zu müssen
	/// Nachteil: Muss in der GUI immer mit <Name>.Value angesprochen werden
	/// </summary>
	public BindableProperty<string> Hallo { get; set; } = new();

	public ObservableCollection<string> Texte { get; set; } = ["ABC", "DEF", "GHI"];

	public MainWindow()
	{
		InitializeComponent();
		//this.DataContext = this;
	}

	#region Events
	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Zaehler++;
		//Notify(nameof(Zaehler)); //Jetzt funktioniert das Aktualisieren
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		Texte.Add("Hallo");
		Hallo.Value = Random.Shared.Next().ToString();
	}
	#endregion
}