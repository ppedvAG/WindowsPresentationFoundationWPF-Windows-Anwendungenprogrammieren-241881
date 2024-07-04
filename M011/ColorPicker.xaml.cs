using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace M011;

public partial class ColorPicker : UserControl
{
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
			new FrameworkPropertyMetadata(Colors.Transparent, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
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

	private static void SliderValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		double a = (double) d.GetValue(AlphaValueProperty);
		double r = (double) d.GetValue(RedValueProperty);
		double g = (double) d.GetValue(GreenValueProperty);
		double b = (double) d.GetValue(BlueValueProperty);
		Color theColor = Color.FromArgb((byte) a, (byte) r, (byte) g, (byte) b);
		d.SetValue(PickedColorProperty, theColor);
	}
}