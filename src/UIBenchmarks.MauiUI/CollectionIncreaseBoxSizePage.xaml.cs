using CommunityToolkit.Mvvm.DependencyInjection;
using UIBenchmarks.ViewModels;

namespace UIBenchmarks.MauiUI;

public partial class CollectionIncreaseBoxSizePage : ContentPage
{
    private IncreasingBoxHeightViewModel vm;

    public CollectionIncreaseBoxSizePage()
    {
        InitializeComponent();
        this.BindingContext = this.vm = Ioc.Default.GetRequiredService<IncreasingBoxHeightViewModel>();
    }
}