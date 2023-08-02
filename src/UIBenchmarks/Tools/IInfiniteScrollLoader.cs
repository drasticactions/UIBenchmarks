namespace UIBenchmarks.Tools;

public interface IInfiniteScrollLoader
{
    bool CanLoadMore { get; }

    Task LoadMoreAsync();
}