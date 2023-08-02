using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.DependencyInjection;
using Drastic.Tools;
using UIBenchmarks.ViewModels;

namespace UIBenchmarks.MauiUI;

public partial class SocialMediaListPage : ContentPage
{
    private SocialMediaViewModel vm;
    
    public SocialMediaListPage()
    {
        InitializeComponent();
        this.BindingContext = vm = Ioc.Default.GetRequiredService<SocialMediaViewModel>();
        Task.Run(() => this.vm.OnLoad()).FireAndForgetSafeAsync();
    }
}