using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIBenchmarks.Models;

namespace UIBenchmarks.MauiUI;

public partial class PostContentView : ContentView
{
    public static readonly BindableProperty EmbedProperty =
        BindableProperty.Create(nameof(Embed), typeof(Post), typeof(PostContentView), default(Post), propertyChanged: OnChanged);

    private static void OnChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var item = (PostContentView)bindable;
        item.OnPropertyChanged("Embed");
    }

    public Post Embed {
        get { return (Post)GetValue(EmbedProperty); }
        set { SetValue(EmbedProperty, value); }
    }
    
    public PostContentView()
    {
        InitializeComponent();
    }
}