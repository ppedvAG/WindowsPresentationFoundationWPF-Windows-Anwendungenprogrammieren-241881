using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace M011;

//Wenn zwischen die XML Tags ein Wert geschrieben wird, kann dieser mit ContentProperty in ein bestimmtes Feld umgeleitet werden
[ContentProperty("Test")]
public partial class ColorPicker : UserControl
{
	public string Test {  get; set; }

	public ColorPicker()
	{
		InitializeComponent();
	}

	public Color PickedColor
	{
		get => (Color) GetValue(PickedColorProperty);
		set => SetValue(PickedColorProperty, value);
	}

	public static readonly DependencyProperty PickedColorProperty =
		DependencyProperty.Register
		(
			nameof(PickedColor), //Name des dahinterliegenden C# Properties
			typeof(Color), //Typ des Properties
			typeof(ColorPicker), //Typ der Klasse herum
			new FrameworkPropertyMetadata(Colors.Transparent, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, PickedColorChanged)
			//Verschiedene Einstellungen vornehmen (z.B. Standardwert, BindingMode, ...)
			//Standardwert, Methode die nach der Änderung passieren soll, Methode die vor der Änderung passieren soll
		);



	public double RedValue
	{
		get => (double) GetValue(RedValueProperty);
		set => SetValue(RedValueProperty, value);
	}

	public static readonly DependencyProperty RedValueProperty =
		DependencyProperty.Register
		(
			nameof(RedValue),
			typeof(double),
			typeof(ColorPicker),
			new PropertyMetadata(0.0, SliderValueChanged)
		);





	public double GreenValue
	{
		get => (double) GetValue(GreenValueProperty);
		set => SetValue(GreenValueProperty, value);
	}

	public static readonly DependencyProperty GreenValueProperty =
		DependencyProperty.Register
		(
			nameof(GreenValue),
			typeof(double),
			typeof(ColorPicker),
			new PropertyMetadata(0.0, SliderValueChanged)
		);




	public double BlueValue
	{
		get => (double) GetValue(BlueValueProperty);
		set => SetValue(BlueValueProperty, value);
	}

	public static readonly DependencyProperty BlueValueProperty =
		DependencyProperty.Register
		(
			nameof(BlueValue),
			typeof(double),
			typeof(ColorPicker),
			new PropertyMetadata(0.0, SliderValueChanged)
		);





	public double AlphaValue
	{
		get => (double) GetValue(AlphaValueProperty);
		set => SetValue(AlphaValueProperty, value);
	}

	public static readonly DependencyProperty AlphaValueProperty =
		DependencyProperty.Register
		(
			nameof(AlphaValue),
			typeof(double),
			typeof(ColorPicker),
			new PropertyMetadata(0.0, SliderValueChanged)
		);

	/// <summary>
	/// Die 4 Slider zu einer Gesamtfarbe übersetzen
	/// Wird immer aufgerufen, wenn ein Slider verändert wird
	/// </summary>
	private static void SliderValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		double a = (double) d.GetValue(AlphaValueProperty);
		double r = (double) d.GetValue(RedValueProperty);
		double g = (double) d.GetValue(GreenValueProperty);
		double b = (double) d.GetValue(BlueValueProperty);
		Color theColor = Color.FromArgb((byte) a, (byte) r, (byte) g, (byte) b);
		d.SetValue(PickedColorProperty, theColor);
	}

	/// <summary>
	/// Wenn die Gesamtfarbe gesetzt wird, werden die 4 Slider gesetzt
	/// Wird aufgerufen, wenn per Binding eine Farbe von außen geschrieben wird
	/// </summary>
	private static void PickedColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		Color c = (Color) d.GetValue(PickedColorProperty);
		d.SetValue(RedValueProperty, (double) c.R);
		d.SetValue(GreenValueProperty, (double) c.G);
		d.SetValue(BlueValueProperty, (double) c.B);
		d.SetValue(AlphaValueProperty, (double) c.A);
	}

	private void ColorSlider_SliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	{
		//MessageBox.Show(e.NewValue.ToString());
	}
}