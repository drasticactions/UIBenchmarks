using UIBenchmarks.Models;

namespace UIBenchmarks.AppleUIKit.Views;

public class PodcastArtworkCollectionViewCell : UICollectionViewCell
{
    public PodcastArtworkView ArtworkView { get; private set; }

    public static string CellIdentifier => "PodcastArtworkCollectionViewCell";
    
    [Export("initWithFrame:")]
    public PodcastArtworkCollectionViewCell(CoreGraphics.CGRect frame) : base(frame)
    {
        ArtworkView = new PodcastArtworkView();
        ContentView.AddSubview(ArtworkView);

        // Set AutoLayout constraints for the PodcastArtworkView
        ArtworkView.TranslatesAutoresizingMaskIntoConstraints = false;
        ArtworkView.TopAnchor.ConstraintEqualTo(ContentView.TopAnchor).Active = true;
        ArtworkView.LeadingAnchor.ConstraintEqualTo(ContentView.LeadingAnchor).Active = true;
        ArtworkView.TrailingAnchor.ConstraintEqualTo(ContentView.TrailingAnchor).Active = true;
        ArtworkView.BottomAnchor.ConstraintEqualTo(ContentView.BottomAnchor).Active = true;
    }

    public void UpdateItem(PodcastItem item)
    {
        ArtworkView.UpdateItem(item);
    }
}