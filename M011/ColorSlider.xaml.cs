using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace M011;

public partial class ColorSlider : UserControl
{
	public ColorSlider() => InitializeComponent();



	public string Text
	{
		get => (string) GetValue(TestProperty);
		set => SetValue(TestProperty, value);
	}

	public static readonly DependencyProperty TestProperty =
		DependencyProperty.Register
		(
			nameof(Text),
			typeof(string),
			typeof(ColorSlider),
			new PropertyMetadata("")
		);



	public Brush TextColor
	{
		get => (Brush) GetValue(TextColorProperty);
		set => SetValue(TextColorProperty, value);
	}

	public static readonly DependencyProperty TextColorProperty =
		DependencyProperty.Register
		(
			nameof(TextColor),
			typeof(Brush),
			typeof(ColorSlider),
			new PropertyMetadata(new SolidColorBrush(Colors.Transparent))
		);



	public double SliderValue
	{
		get => (double) GetValue(SliderValueProperty);
		set => SetValue(SliderValueProperty, value);
	}

	public static readonly DependencyProperty SliderValueProperty =
		DependencyProperty.Register
		(
			nameof(SliderValue),
			typeof(double),
			typeof(ColorSlider),
			new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
		);



	public event RoutedPropertyChangedEventHandler<double> SliderValueChanged
	{
		add { AddHandler(SliderValueChangedEvent, value); }
		remove { RemoveHandler(SliderValueChangedEvent, value); }
	}

	public static readonly RoutedEvent SliderValueChangedEvent =
		EventManager.RegisterRoutedEvent
		(
			nameof(SliderValueChanged),
			RoutingStrategy.Direct,
			//RoutingStrategy: Bestimmt in welcher Reihenfolge Events ausgeführt werden
			//Bubbling: Innen nach außen
			//Tunneling: Außen nach Innen
			//Direct: Umgeht den Baum komplett
			typeof(RoutedPropertyChangedEventHandler<double>),
			typeof(ColorSlider)
		);

	private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	{
		e.RoutedEvent = SliderValueChangedEvent;
		RaiseEvent(e);
	}
}