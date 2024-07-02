using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace M002;

public partial class MainWindow : Window
{
	private int zaehler;

	public MainWindow()
	{
		InitializeComponent();
		CB.ItemsSource = Enumerable.Range(0, 10);
	}

	/// <summary>
	/// Diese Methode ist im XAML angehängt an Button.Click
	/// Wenn der Button geklickt wird, wird der Code ausgeführt
	/// 
	/// Aufgabenstellung: Zähler um 1 erhöhen, und im TextBlock anzeigen
	/// </summary>
	private void Button_Click(object sender, RoutedEventArgs e)
	{
		zaehler++;
		Output.Text = zaehler.ToString();
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		Output.Text = Input.Text;
    }

	private void Input_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Key == Key.Enter)
		{
			Output.Text = Input.Text;
		}
	}

	/// <summary>
	/// Wird gefeuert, wenn der User ein Element auswählt
	/// 
	/// Aufgabenstellung: Das ausgewählte Element im Output anzeigen
	/// </summary>
	private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		Output.Text = CB.SelectedItem.ToString();
	}

	private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	{
		SliderOutput.Text = e.NewValue.ToString();
	}

	private void MenuItem_Click(object sender, RoutedEventArgs e)
	{
		MessageBoxResult result = MessageBox.Show("Willst du wirklich beenden?", "Beenden", MessageBoxButton.YesNo, MessageBoxImage.Question);
		if (result == MessageBoxResult.Yes)
		{
			Close();
		}
	}
}