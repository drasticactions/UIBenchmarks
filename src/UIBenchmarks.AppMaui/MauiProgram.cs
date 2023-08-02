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

		var mauiAppDispatcher = new MauiAppDispatcher();
		var basicErrorHandler = new BasicErrorHandler();

		builder.
			Services.
			AddSingleton<IAppDispatcher>(mauiAppDispatcher).
			AddSingleton<IErrorHandlerService>(basicErrorHandler)
			.AddSingleton<VirtualListViewModel>()
			;

		ServiceInitialize.Setup(mauiAppDispatcher, basicErrorHandler);

		builder
			.UseMauiApp<App>()
			.UseVirtualListView()
			.ConfigureFonts(fonts =>
			{
				// fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				// fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
