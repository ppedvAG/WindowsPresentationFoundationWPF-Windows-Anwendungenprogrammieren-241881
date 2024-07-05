using System.Windows.Input;

namespace M000.Util;

/// <summary>
/// Diese Klasse soll eine beliebige Methode empfangen können, und diese ausführen können
/// </summary>
public class CustomCommand : ICommand
{
	public event EventHandler? CanExecuteChanged;

	/// <summary>
	/// Action: Methodenzeiger, welcher void zurückgibt und beliebig viele Parameter hat
	/// 
	/// Methodenzeiger, welcher eine Methode halten kann, die einen Object Parameter hat und void zurückgibt
	/// </summary>
	public Action<object> _execute;

	/// <summary>
	/// Func: Methodenzeiger, welcher einen beliebigen Typen zurückgibt (hier bool) und beliebig viele Parameter hat
	/// </summary>
	public Func<object, bool> _canExecute;

	public void Execute(object? parameter)
	{
		_execute?.Invoke(parameter);
	}

	public bool CanExecute(object? parameter)
	{
		bool? b = _canExecute?.Invoke(parameter);
		return b == true || b == null;
	}
}