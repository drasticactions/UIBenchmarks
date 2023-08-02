using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIBenchmarks.Models;

namespace UIBenchmarks.MauiUI;

public partial class ExternalEmbedView : ContentView
{
    public static readonly BindableProperty EmbedProperty =
        BindableProperty.Create(nameof(Embed), typeof(ExternalEmbed), typeof(ExternalEmbedView), default(ExternalEmbed), propertyChanged: OnPostUpdate);

    public ExternalEmbed? Embed
    {
        get { return (ExternalEmbed)GetValue(EmbedProperty); }
        set { SetValue(EmbedProperty, value); }
    }

    private static void OnPostUpdate(BindableObject bindable, object oldValue, object newValue)
    {
        var view = (ExternalEmbedView)bindable;
        view.OnPropertyChanged("Embed");
        view.MainGrid.BindingContext = newValue;
    }
    
    public ExternalEmbedView()
    {
        InitializeComponent();
    }
}