using System.Windows;
using System.Windows.Media;

namespace M011;

public partial class MainWindow : Window
{
	public Color SelectedColor { get; set; } = Colors.Honeydew;

	public MainWindow()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		this.Title += "B";
	}

	private void StackPanel_Click(object sender, RoutedEventArgs e)
	{
		this.Title += "S";
	}

	private void Window_Click(object sender, RoutedEventArgs e)
	{
		this.Title += "W";
	}
}