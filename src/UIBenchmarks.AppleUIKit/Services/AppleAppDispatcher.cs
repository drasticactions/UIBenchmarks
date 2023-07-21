using Drastic.Services;

namespace UIBenchmarks.AppleUIKit.Services;

public class AppleAppDispatcher : NSObject, IAppDispatcher
{
    public bool Dispatch(Action action)
    {
        this.InvokeOnMainThread(action);
        return true;
    }
}
