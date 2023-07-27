using Drastic.ViewModels;
using System.Collections.ObjectModel;

namespace UIBenchmarks.ViewModels;

public class UriImagePlaceholderViewModel : BaseViewModel
{
    public UriImagePlaceholderViewModel(IServiceProvider services)
        : base(services)
    {
        for(var i = 0; i < 100; ++i)
        {
            this.ImageUrls.Add($"https://picsum.photos/200/300");
        }
    }

    public List<string> ImageUrls { get; } = new List<string>();
}
