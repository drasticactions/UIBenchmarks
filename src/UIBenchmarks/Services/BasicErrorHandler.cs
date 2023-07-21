using Drastic.Services;

namespace UIBenchmarks.Services;

public class BasicErrorHandler : IErrorHandlerService
{
    public void HandleError(Exception ex)
    {
        System.Diagnostics.Debug.WriteLine(ex);
    }
}
