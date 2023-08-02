using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIBenchmarks.AppMaui;

public partial class VirtualListViewIncreaseBoxSizePage : ContentPage
{
    private VirtualListViewModel vm;
    
    public VirtualListViewIncreaseBoxSizePage(IServiceProvider services)
    {
        InitializeComponent();
        this.BindingContext = this.vm = services.GetRequiredService<VirtualListViewModel>();
    }
}