using Drastic.Services;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace UIBenchmarks.Tools;

public class InfiniteScrollCollection<T> : ObservableCollection<T>, IInfiniteScrollLoader, IInfiniteScrollLoading
{
    private bool isLoadingMore;
    private IAppDispatcher dispatcher;

    public InfiniteScrollCollection(IAppDispatcher dispatcher)
    {
        this.dispatcher = dispatcher;
    }

    public InfiniteScrollCollection(IAppDispatcher dispatcher, IEnumerable<T> collection)
        : base(collection)
    {
        this.dispatcher = dispatcher;
    }

    public Action OnBeforeLoadMore { get; set; }

    public Action OnAfterLoadMore { get; set; }

    public Action<Exception> OnError { get; set; }

    public Func<bool> OnCanLoadMore { get; set; }

    public Func<Task<IEnumerable<T>>> OnLoadMore { get; set; }

    public virtual bool CanLoadMore => OnCanLoadMore?.Invoke() ?? true;

    public bool IsLoadingMore {
        get => isLoadingMore;
        private set {
            if (isLoadingMore != value)
            {
                isLoadingMore = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(IsLoadingMore)));

                LoadingMore?.Invoke(this, new LoadingMoreEventArgs(IsLoadingMore));
            }
        }
    }

    public event EventHandler<LoadingMoreEventArgs> LoadingMore;

    public async Task LoadMoreAsync()
    {
        try
        {
            IsLoadingMore = true;
            OnBeforeLoadMore?.Invoke();

            var result = await OnLoadMore();

            if (result != null)
            {
                this.dispatcher.Dispatch(() => AddRange(result));
            }
        }
        catch (Exception ex) when (OnError != null)
        {
            OnError.Invoke(ex);
        }
        finally
        {
            IsLoadingMore = false;
            OnAfterLoadMore?.Invoke();
        }
    }

    public void AddRange(IEnumerable<T> collection)
    {
        if (collection == null)
            throw new ArgumentNullException(nameof(collection));

        CheckReentrancy();

        var startIndex = Count;
        var changedItems = new List<T>(collection);

        foreach (var i in changedItems)
            Items.Add(i);

        OnPropertyChanged(new PropertyChangedEventArgs("Count"));
        OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));

        if (changedItems.Count > 0)
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, changedItems, startIndex));
    }
}