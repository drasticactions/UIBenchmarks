﻿namespace UIBenchmarks.AppMaui;

public partial class App : Application
{
	public App(IServiceProvider provider)
	{
		InitializeComponent();

		MainPage = new MainPage(provider);
	}
}
