using System.Windows.Input;

namespace M013;

/// <summary>
/// Commands benötigen das ICommand Interface
/// Execute: Der Code der beim Ausführen des Commands passieren soll
/// CanExecute: Deaktiviert die Komponente, wenn hier false zurück kommt
/// </summary>
public class CloseCommand : ICommand
{
	public event EventHandler? CanExecuteChanged;

	public void Execute(object? parameter)
	{
		MainWindow mw = (MainWindow)parameter;
		mw.Close();
	}

	public bool CanExecute(object? parameter)
	{
		return true;
	}
}