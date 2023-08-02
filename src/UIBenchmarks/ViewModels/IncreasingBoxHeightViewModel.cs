using Drastic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIBenchmarks.ViewModels;

public class IncreasingBoxHeightViewModel : BaseViewModel
{
    public IncreasingBoxHeightViewModel(IServiceProvider services)
        : base(services)
    {
        // Size of 0 Breaks iOS/Catalyst MAUI
        // Switch to 1 for it to "work"
        // It also doesn't seem to like a ton of items in the list.
        for(var i = 0; i < 1000; ++i)
        {
            this.Boxes.Add(new BoxSize() { Height = i });
        }
    }

    public List<BoxSize> Boxes { get; } = new List<BoxSize>();
}

public class BoxSize
{
    public int Width { get; set; } = 5;
    public int Height { get; set; } = 5;
}
