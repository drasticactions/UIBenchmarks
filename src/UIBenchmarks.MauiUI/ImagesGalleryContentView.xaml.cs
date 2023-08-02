using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Shapes;
using UIBenchmarks.Models;
using UIBenchmarks.ViewModels;

namespace UIBenchmarks.MauiUI;

public partial class ImagesGalleryContentView : ContentView
{
    public static readonly BindableProperty ImagesProperty =
        BindableProperty.Create(nameof(Images), typeof(ImageEmbed), typeof(ImagesGalleryContentView), default(ImageEmbed), propertyChanged: OnPostUpdate);

    public ImageEmbed? Images
    {
        get { return (ImageEmbed)GetValue(ImagesProperty); }
        set { SetValue(ImagesProperty, value); }
    }
    public ImagesGalleryContentView()
    {
        InitializeComponent();
    }
    
    private static void OnPostUpdate(BindableObject bindable, object oldValue, object newValue)
    {
        var view = (ImagesGalleryContentView)bindable;
        view.UpdateGrid();
    }
    
    private void UpdateGrid()
    {
        this.MainGrid.Clear();

        switch (this.Images?.Urls.Count())
        {
            case 1:
                OneImage(this.Images.Urls, this.MainGrid);
                break;
            case 2:
                TwoImages(this.Images.Urls, this.MainGrid);
                break;
            case 3:
                ThreeImages(this.Images.Urls, this.MainGrid);
                break;
            case 4:
                FourImages(this.Images.Urls, this.MainGrid);
                break;
        }
    }
    
    private IView GenerateImage(string uri, Aspect aspect = Aspect.AspectFill)
    {
        var border = new Border() { StrokeShape = new RoundRectangle() { CornerRadius = 5 }, StrokeThickness = 0 };
        var image = new Microsoft.Maui.Controls.Image { Aspect = aspect };
        image.Source = new UriImageSource { Uri = new Uri(uri), CachingEnabled = false };
        border.Content = image;
        return border;
    }

    private void OneImage(List<string> uris, Grid grid)
    {
        var image = this.GenerateImage(uris[0], Aspect.AspectFit);
        grid.Children.Add(image);
        grid.SetRow(image, 0);
        grid.SetColumn(image, 0);
        grid.SetRowSpan(image, 2);
        grid.SetColumnSpan(image, 2);
    }

    private void TwoImages(List<string> uris, Grid grid)
    {
        var image1 = this.GenerateImage(uris[0]);
        grid.Children.Add(image1);
        grid.SetRow(image1, 0);
        grid.SetColumn(image1, 0);
        grid.SetRowSpan(image1, 2);
        var image2 = this.GenerateImage(uris[1]);
        grid.Children.Add(image2);
        grid.SetRow(image2, 0);
        grid.SetColumn(image2, 1);
        grid.SetRowSpan(image2, 2);
    }

    private void ThreeImages(List<string> uris, Grid grid)
    {
        grid.ColumnDefinitions[0].Width = new GridLength(1.5, GridUnitType.Star);
        var image3 = this.GenerateImage(uris[0]);
        grid.Children.Add(image3);
        grid.SetRow(image3, 0);
        grid.SetColumn(image3, 0);
        grid.SetRowSpan(image3, 2);
        var image4 = this.GenerateImage(uris[1]);
        grid.Children.Add(image4);
        grid.SetRow(image4, 0);
        grid.SetColumn(image4, 1);
        var image5 = this.GenerateImage(uris[2]);
        grid.Children.Add(image5);
        grid.SetRow(image5, 1);
        grid.SetColumn(image5, 1);
    }

    private void FourImages(List<string> uris, Grid grid)
    {
        var image6 = this.GenerateImage(uris[0]);
        grid.Children.Add(image6);
        grid.SetRow(image6, 0);
        grid.SetColumn(image6, 0);
        var image7 = this.GenerateImage(uris[1]);
        grid.Children.Add(image7);
        grid.SetRow(image7, 0);
        grid.SetColumn(image7, 1);
        var image8 = this.GenerateImage(uris[2]);
        grid.Children.Add(image8);
        grid.SetRow(image8, 1);
        grid.SetColumn(image8, 0);
        var image9 = this.GenerateImage(uris[3]);
        grid.Children.Add(image9);
        grid.SetRow(image9, 1);
        grid.SetColumn(image9, 1);
    }
}