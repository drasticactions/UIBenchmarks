using System;

namespace UIBenchmarks.MauiUI;

public class ImageContentView : ContentView
{
    public static readonly BindableProperty UriProperty =
      BindableProperty.Create(nameof(Uri), typeof(string), typeof(ImageContentView), default(string), propertyChanged: OnImageUpdate);

    public string Uri {
        get { return (string)GetValue(UriProperty); }
        set { SetValue(UriProperty, value); }
    }

    public ImageContentView()
    {
    }

    private static void OnImageUpdate(BindableObject bindable, object oldValue, object newValue)
    {
        var view = (ImageContentView)bindable;
        view.UpdateImage();
    }

    public void UpdateImage()
    {
        this.Content = null;

        System.Diagnostics.Debug.WriteLine($"Image: {this.Uri}");

        if (!global::System.Uri.TryCreate(this.Uri, UriKind.Absolute, out Uri? uri))
        {
            return;
        }

        var image = new Image() { WidthRequest = this.WidthRequest, HeightRequest = this.HeightRequest };
        image.Source = new UriImageSource() { Uri = uri, CachingEnabled = true };
        this.Content = image;
    }
}