using System.ComponentModel;
using System.Windows;

namespace M009;

public partial class MainWindow : Window, IDataErrorInfo
{
	public string UserInput { get; set; }

	private string exceptionInput;

	public string ExceptionInput
	{
		get => exceptionInput;
		set
		{
			if (value.Length <= 3 || value.Length >= 15)
				throw new ArgumentException("Die Länge des Textes ist invalide");

			exceptionInput = value;
		}
	}

	private string dataErrorInput = "";

	public string DataErrorInput
	{
		get => dataErrorInput;
		set => dataErrorInput = value;
	}

	/// <summary>
	/// Kann ignoriert werden
	/// </summary>
	public string Error => throw new NotImplementedException();

	/// <summary>
	/// Der Indexer, welcher die Validierung durchführt
	/// Wenn das Binding ausgeführt wird, wird hier anhand des Variablennamens die Prüfung durchgeführt
	/// 
	/// Wenn dieser Indexer null zurückgibt, gibt es keine Validierungsfehler
	/// Wenn ein String zurückkommt, gibt es einen Validierungsfehler
	/// 
	/// this[]: Indexer, ermöglicht das Verwenden von [] bei Objekten
	/// </summary>
	public string this[string columnName]
	{
		get
		{
			switch(columnName)
			{
				case nameof(ExceptionInput):
					if (!ExceptionInput.All(char.IsLetter))
						return "Die Zeichen dürfen nicht numerisch sein!";
					break;

				case nameof(DataErrorInput):
					if (DataErrorInput.Length <= 3 || DataErrorInput.Length >= 15)
						return "Der Input muss zw. 3 und 15 Zeichen haben";
					break;
			}

			return null;
		}
	}

	public MainWindow()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{

	}
}