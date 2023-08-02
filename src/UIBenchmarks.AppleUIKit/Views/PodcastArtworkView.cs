using UIBenchmarks.Models;

namespace UIBenchmarks.AppleUIKit.Views;

public class PodcastArtworkView : UIView
{
    private UIImageView _imageView;
    private PodcastItem? item;
    
    public PodcastArtworkView()
    {
        InitializeViews();
        SetupConstraints();
    }
    
    public PodcastArtworkView(PodcastItem item)
    {
        this.item = item;
        InitializeViews();
        SetupConstraints();
    }

    private void InitializeViews()
    {
        _imageView = new UIImageView
        {
            ContentMode = UIViewContentMode.ScaleAspectFit,
            TranslatesAutoresizingMaskIntoConstraints = false,
            BackgroundColor = UIColor.Green
        };

        AddSubview(_imageView);
    }

    private void SetupConstraints()
    {
        _imageView.TopAnchor.ConstraintEqualTo(TopAnchor).Active = true;
        _imageView.LeadingAnchor.ConstraintEqualTo(LeadingAnchor).Active = true;
        _imageView.TrailingAnchor.ConstraintEqualTo(TrailingAnchor).Active = true;
        _imageView.BottomAnchor.ConstraintEqualTo(BottomAnchor).Active = true;
    }

    public void UpdateItem(PodcastItem item)
    {
        this.item = item;
    }

    // Method to update the podcast artwork image
    private void UpdateArtwork(UIImage artworkImage)
    {
        _imageView.Image = artworkImage;
    }
}