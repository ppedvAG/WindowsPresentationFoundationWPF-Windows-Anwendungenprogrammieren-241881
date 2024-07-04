using System.Collections.ObjectModel;
using System.Windows;

namespace M008;

public partial class MainWindow : Window
{
	public ObservableCollection<DayOfWeek> EnumWerte { get; set; } = new ObservableCollection<DayOfWeek>(Enum.GetValues<DayOfWeek>());

	public ObservableCollection<int> Zahlen { get; set; } = new ObservableCollection<int>(Enumerable.Range(0, 5));

	public MainWindow()
	{
		InitializeComponent();
	}
}