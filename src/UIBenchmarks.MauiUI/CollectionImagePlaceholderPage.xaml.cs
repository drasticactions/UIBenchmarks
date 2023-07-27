using CommunityToolkit.Mvvm.DependencyInjection;
using UIBenchmarks.ViewModels;

namespace UIBenchmarks.MauiUI;

public partial class CollectionImagePlaceholderPage : ContentPage
{
    private UriImagePlaceholderViewModel vm;

    public CollectionImagePlaceholderPage()
	{
		InitializeComponent();
        this.BindingContext = this.vm = Ioc.Default.GetRequiredService<UriImagePlaceholderViewModel>();
    }
}