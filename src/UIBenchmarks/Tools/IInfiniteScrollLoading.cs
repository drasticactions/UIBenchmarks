namespace UIBenchmarks.Tools;

public interface IInfiniteScrollLoading
{
    bool IsLoadingMore { get; }

    event EventHandler<LoadingMoreEventArgs> LoadingMore;
}