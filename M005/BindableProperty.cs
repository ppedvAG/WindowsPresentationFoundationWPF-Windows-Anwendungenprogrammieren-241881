﻿using System.ComponentModel;

namespace M005;

public class BindableProperty<T> : INotifyPropertyChanged
{
	private T _value;

	public T Value
	{
		get => _value;
		set
		{
			_value = value;
			Notify(nameof(Value));
		}
	}

	public event PropertyChangedEventHandler? PropertyChanged;

	public void Notify(string prop) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
}