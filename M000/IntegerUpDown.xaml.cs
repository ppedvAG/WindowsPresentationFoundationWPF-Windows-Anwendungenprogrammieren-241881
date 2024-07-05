using System.Windows;
using System.Windows.Controls;

namespace M000;

public partial class IntegerUpDown : UserControl
{
	public IntegerUpDown() => InitializeComponent();

	public int Number
	{
		get => (int) GetValue(NumberProperty);
		set => SetValue(NumberProperty, value);
	}

	public static readonly DependencyProperty NumberProperty =
		DependencyProperty.Register
		(
			nameof(Number),
			typeof(int),
			typeof(IntegerUpDown),
			new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);

	private void Button_Click(object sender, RoutedEventArgs e) => Number++;

	private void Button_Click_1(object sender, RoutedEventArgs e) => Number--;
}