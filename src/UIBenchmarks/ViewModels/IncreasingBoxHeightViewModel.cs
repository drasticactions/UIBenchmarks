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
