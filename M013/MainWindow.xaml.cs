using System.Windows;

namespace M013;

public partial class MainWindow : Window
{
	public CloseCommand Close { get; set; } = new();

	public CustomCommand CustomCommand { get; set; } = new();

	public MainWindow()
	{
		InitializeComponent();
		CustomCommand._execute = CloseWindow; //Methodenzeiger hier anhängen
	}

	private void Button_Click(object sender, RoutedEventArgs e) { }

	public void CloseWindow(object x)
	{
		MainWindow mw = (MainWindow) x;
		mw.Close();
	}
}