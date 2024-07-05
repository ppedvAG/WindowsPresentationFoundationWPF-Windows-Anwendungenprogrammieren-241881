using System.Collections.ObjectModel;

namespace M012;

public static class ExtensionMethods
{
	//this um den Typen anzugeben, an den die Methode angehängt werden soll
	public static void AddRange<T>(this ObservableCollection<T> o, IEnumerable<T> values)
	{
		foreach (T v in values)
			o.Add(v);
	}
}