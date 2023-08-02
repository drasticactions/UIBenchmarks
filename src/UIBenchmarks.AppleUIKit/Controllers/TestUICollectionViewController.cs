using UIBenchmarks.AppleUIKit.Views;

namespace UIBenchmarks.AppleUIKit.Controllers;

public class TestUICollectionViewController : UICollectionViewController
{
    public TestUICollectionViewController()
    {
        this.CollectionView = new PodcastArtworkCollectionView(View.Frame, new UICollectionViewFlowLayout());
    }
}