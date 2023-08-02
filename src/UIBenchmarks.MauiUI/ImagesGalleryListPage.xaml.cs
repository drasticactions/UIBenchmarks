using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.DependencyInjection;
using UIBenchmarks.ViewModels;

namespace UIBenchmarks.MauiUI;

public partial class ImagesGalleryListPage : ContentPage
{
    private ImageGalleryViewModel vm;
    
    public ImagesGalleryListPage()
    {
        InitializeComponent();
        this.BindingContext = this.vm = Ioc.Default.GetRequiredService<ImageGalleryViewModel>();
    }
}