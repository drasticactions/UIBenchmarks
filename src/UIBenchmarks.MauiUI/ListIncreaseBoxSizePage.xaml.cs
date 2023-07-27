using CommunityToolkit.Mvvm.DependencyInjection;
using UIBenchmarks.ViewModels;

namespace UIBenchmarks.MauiUI;

public partial class ListIncreaseBoxSizePage : ContentPage
{
    private IncreasingBoxHeightViewModel vm;

    public ListIncreaseBoxSizePage()
    {
        InitializeComponent();
        this.BindingContext = this.vm = Ioc.Default.GetRequiredService<IncreasingBoxHeightViewModel>();
    }
}