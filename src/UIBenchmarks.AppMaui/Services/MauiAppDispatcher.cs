using Drastic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIBenchmarks.AppMaui.Services;

internal class MauiAppDispatcher : IAppDispatcher
{
    public bool Dispatch(Action action)
    {
        return Microsoft.Maui.Controls.Application.Current.Dispatcher.Dispatch(action);
    }
}
