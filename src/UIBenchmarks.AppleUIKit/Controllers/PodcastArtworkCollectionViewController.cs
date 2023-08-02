using UIBenchmarks.AppleUIKit.Views;

namespace UIBenchmarks.AppleUIKit.Controllers;

public class PodcastArtworkCollectionViewController : UIViewController
{
    public UICollectionView CollectionView { get; private set; }

    public PodcastArtworkCollectionViewController()
    {
        this.CollectionView = new PodcastArtworkCollectionView(View.Frame, new UICollectionViewLayout())
    }
}