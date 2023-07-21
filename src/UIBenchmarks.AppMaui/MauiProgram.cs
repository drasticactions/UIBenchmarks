using Drastic.Services;
using Microsoft.Extensions.Logging;
using UIBenchmarks.AppMaui.Services;
using UIBenchmarks.Services;

namespace UIBenchmarks.AppMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		builder.
			Services.
			AddSingleton<IAppDispatcher, MauiAppDispatcher>().
			AddSingleton<IErrorHandlerService, BasicErrorHandler>()
			;

		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
