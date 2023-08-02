using Drastic.ViewModels;
using Microsoft.Maui.Adapters;
using UIBenchmarks.ViewModels;

namespace UIBenchmarks.AppMaui;

public class VirtualListViewModel : BaseViewModel
{
    
    public VirtualListViewModel(IServiceProvider services)
        : base(services)
    {
       
        // Size of 0 Breaks iOS/Catalyst MAUI
        // Switch to 1 for it to "work"
        // It also doesn't seem to like a ton of items in the list.
        var items = new List<BoxSize>();
        for(var i = 0; i < 1000; ++i)
        {
            items.Add(new BoxSize() { Height = i });
        }

        this.Boxes = new VirtualListViewAdapter<BoxSize>(items);
    }

    public VirtualListViewAdapter<BoxSize> Boxes { get; }
}