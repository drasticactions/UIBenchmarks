using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIBenchmarks.MauiUI;

public partial class AvatarView : ContentView
{
    public static readonly BindableProperty EmbedProperty =
        BindableProperty.Create(nameof(Embed), typeof(Uri), typeof(AvatarView), default(Uri), propertyChanged: OnChanged);

    private static void OnChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var item = (AvatarView)bindable;
        //item.OnPropertyChanged("Embed");
        item.TestImage.Source = new UriImageSource() { Uri = (Uri)(newvalue), CachingEnabled = true};
    }

    public Uri Embed {
        get { return (Uri)GetValue(EmbedProperty); }
        set { SetValue(EmbedProperty, value); }
    }
    
    public AvatarView()
    {
        InitializeComponent();
    }
}