using CommunityToolkit.Mvvm.DependencyInjection;
using UIBenchmarks.ViewModels;

namespace UIBenchmarks.MauiUI;

public partial class ImagePlaceholderPage : ContentPage
{
    private UriImagePlaceholderViewModel vm;

    public ImagePlaceholderPage()
    {
        InitializeComponent();
        this.BindingContext = this.vm = Ioc.Default.GetRequiredService<UriImagePlaceholderViewModel>();
    }
}