using UIBenchmarks.AppleUIKit.Services;

namespace UIBenchmarks.tvOS;

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate {
	public override UIWindow? Window {
		get;
		set;
	}

	public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
	{
        UIBenchmarks.Services.ServiceInitialize.Setup(new AppleAppDispatcher(), new UIBenchmarks.Services.BasicErrorHandler());
        // Override point for customization after application launch.
        // If not required for your application you can safely delete this method

        return true;
	}
}
