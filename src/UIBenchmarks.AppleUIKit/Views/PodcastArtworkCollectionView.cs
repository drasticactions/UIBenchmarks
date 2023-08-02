using UIBenchmarks.Models;

namespace UIBenchmarks.AppleUIKit.Views;

public class PodcastArtworkCollectionView : UICollectionView, IUICollectionViewDataSource, IUICollectionViewDelegateFlowLayout
{
    private List<PodcastItem> _artworkViews;

    public PodcastArtworkCollectionView(CoreGraphics.CGRect frame, UICollectionViewFlowLayout layout)
        : base(frame, layout)
    {
        InitializeCollectionView();
    }

    private void InitializeCollectionView()
    {
        this._artworkViews = new List<PodcastItem>();
        this._artworkViews.Add(new PodcastItem());
        this._artworkViews.Add(new PodcastItem());
        this._artworkViews.Add(new PodcastItem());
        this._artworkViews.Add(new PodcastItem());
        
        Delegate = this;
        DataSource = this;
        RegisterClassForCell(typeof(PodcastArtworkCollectionViewCell), PodcastArtworkCollectionViewCell.CellIdentifier);
    }

    public void SetArtworkViews(List<PodcastItem> artworkViews)
    {
        _artworkViews = artworkViews;
        ReloadData();
    }

    // UICollectionViewDataSource methods
    [Export("collectionView:numberOfItemsInSection:")]
    public nint GetItemsCount(UICollectionView collectionView, nint section)
    {
        return _artworkViews?.Count ?? 0;
    }

    [Export("collectionView:cellForItemAtIndexPath:")]
    public UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
    {
        var cell = collectionView.DequeueReusableCell(PodcastArtworkCollectionViewCell.CellIdentifier, indexPath) as PodcastArtworkCollectionViewCell;
        cell.UpdateItem(_artworkViews[indexPath.Row]);
        return cell;
    }

    // UICollectionViewDelegateFlowLayout methods
    [Export("collectionView:layout:sizeForItemAtIndexPath:")]
    public CoreGraphics.CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
    {
        // Customize the size of each podcast artwork cell here
        return new CoreGraphics.CGSize(120, 120);
    }

    // Optionally, you can handle user interactions on the podcast artwork cells by implementing the respective UICollectionViewDelegate methods.
}