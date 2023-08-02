namespace UIBenchmarks.Tools;

public interface IInfiniteScrollDetector
{
    bool ShouldLoadMore(object currentItem);
}