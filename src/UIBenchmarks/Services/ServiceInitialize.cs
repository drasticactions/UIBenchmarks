using CommunityToolkit.Mvvm.DependencyInjection;
using Drastic.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIBenchmarks.Services;

public static class ServiceInitialize
{
    public static void Setup(IAppDispatcher dispatcher, IErrorHandlerService error)
    {
        Ioc.Default.ConfigureServices(
                       new ServiceCollection()
                       .AddSingleton<IAppDispatcher>(dispatcher)
                       .AddSingleton<IErrorHandlerService>(error)
                       .BuildServiceProvider()
        );
    }
}
