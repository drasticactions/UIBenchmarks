using UIBenchmarks.Models;

namespace UIBenchmarks.AppleUIKit.Views;

public class SocialMediaView : UIView
{
    private SocialMediaPost? post;

    // UI elements for the tweet view
    private UIImageView profileImageView;
    private UILabel displayNameLabel;
    private UILabel userNameLabel;
    private UILabel tweetTextLabel;
    private UIButton likeButton;
    private UIButton retweetButton;
    private UIButton replyButton;

    public SocialMediaView()
    {
        Initialize();
    }

    public SocialMediaView(SocialMediaPost post)
    {
        this.post = post;
        Initialize();
    }

    public void UpdatePost(SocialMediaPost post)
    {
        this.post = post;
        this.LayoutSubviews();
    }

    private void Initialize()
    {
        this.BackgroundColor = UIColor.Blue;
        // Initialize and add UI elements
        profileImageView = new UIImageView();
        profileImageView.TranslatesAutoresizingMaskIntoConstraints = false;
        profileImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
        AddSubview(profileImageView);

        displayNameLabel = new UILabel();
        displayNameLabel.TranslatesAutoresizingMaskIntoConstraints = false;
        AddSubview(displayNameLabel);

        userNameLabel = new UILabel();
        userNameLabel.TranslatesAutoresizingMaskIntoConstraints = false;
        userNameLabel.TextColor = UIColor.Gray;
        userNameLabel.Font = UIFont.SystemFontOfSize(12);
        AddSubview(userNameLabel);

        tweetTextLabel = new UILabel();
        tweetTextLabel.TranslatesAutoresizingMaskIntoConstraints = false;
        tweetTextLabel.Lines = 0;
        tweetTextLabel.LineBreakMode = UILineBreakMode.WordWrap;
        AddSubview(tweetTextLabel);

        likeButton = new UIButton();
        likeButton.TranslatesAutoresizingMaskIntoConstraints = false;
        likeButton.SetTitle("Like", UIControlState.Normal);
        likeButton.SetTitleColor(UIColor.Blue, UIControlState.Normal);
        AddSubview(likeButton);

        retweetButton = new UIButton();
        retweetButton.TranslatesAutoresizingMaskIntoConstraints = false;
        retweetButton.SetTitle("Retweet", UIControlState.Normal);
        retweetButton.SetTitleColor(UIColor.Blue, UIControlState.Normal);
        AddSubview(retweetButton);

        replyButton = new UIButton();
        replyButton.TranslatesAutoresizingMaskIntoConstraints = false;
        replyButton.SetTitle("Reply", UIControlState.Normal);
        replyButton.SetTitleColor(UIColor.Blue, UIControlState.Normal);
        AddSubview(replyButton);

        SetupConstraints();
    }

    private void SetupConstraints()
    {
        // Profile Image constraints
        profileImageView.TopAnchor.ConstraintEqualTo(TopAnchor, 10).Active = true;
        profileImageView.LeftAnchor.ConstraintEqualTo(LeftAnchor, 10).Active = true;
        profileImageView.WidthAnchor.ConstraintEqualTo(50).Active = true;
        profileImageView.HeightAnchor.ConstraintEqualTo(50).Active = true;

        // Display Name label constraints
        displayNameLabel.TopAnchor.ConstraintEqualTo(TopAnchor, 10).Active = true;
        displayNameLabel.LeftAnchor.ConstraintEqualTo(profileImageView.RightAnchor, 10).Active = true;
        displayNameLabel.RightAnchor.ConstraintEqualTo(RightAnchor, -10).Active = true;
        displayNameLabel.HeightAnchor.ConstraintEqualTo(20).Active = true;

        // User Name label constraints
        userNameLabel.TopAnchor.ConstraintEqualTo(displayNameLabel.BottomAnchor, 5).Active = true;
        userNameLabel.LeftAnchor.ConstraintEqualTo(profileImageView.RightAnchor, 10).Active = true;
        userNameLabel.RightAnchor.ConstraintEqualTo(RightAnchor, -10).Active = true;
        userNameLabel.HeightAnchor.ConstraintEqualTo(20).Active = true;

        // Tweet Text label constraints
        tweetTextLabel.TopAnchor.ConstraintEqualTo(profileImageView.BottomAnchor, 10).Active = true;
        tweetTextLabel.LeftAnchor.ConstraintEqualTo(LeftAnchor, 10).Active = true;
        tweetTextLabel.RightAnchor.ConstraintEqualTo(RightAnchor, -10).Active = true;

        // Action buttons constraints
        likeButton.TopAnchor.ConstraintEqualTo(tweetTextLabel.BottomAnchor, 10).Active = true;
        likeButton.LeftAnchor.ConstraintEqualTo(LeftAnchor, 10).Active = true;
        likeButton.WidthAnchor.ConstraintEqualTo(80).Active = true;
        likeButton.HeightAnchor.ConstraintEqualTo(30).Active = true;

        retweetButton.TopAnchor.ConstraintEqualTo(tweetTextLabel.BottomAnchor, 10).Active = true;
        retweetButton.LeftAnchor.ConstraintEqualTo(likeButton.RightAnchor, 10).Active = true;
        retweetButton.WidthAnchor.ConstraintEqualTo(80).Active = true;
        retweetButton.HeightAnchor.ConstraintEqualTo(30).Active = true;

        replyButton.TopAnchor.ConstraintEqualTo(tweetTextLabel.BottomAnchor, 10).Active = true;
        replyButton.LeftAnchor.ConstraintEqualTo(retweetButton.RightAnchor, 10).Active = true;
        replyButton.WidthAnchor.ConstraintEqualTo(80).Active = true;
        replyButton.HeightAnchor.ConstraintEqualTo(30).Active = true;

        // Bottom padding constraint
        BottomAnchor.ConstraintEqualTo(likeButton.BottomAnchor, 10).Active = true;
    }

    public override void LayoutSubviews()
    {
        base.LayoutSubviews();

        if (this.post is not null)
        {
            // profileImageView.Image = UIImage.FromBundle(post.ProfileImage);
            displayNameLabel.Text = post.DisplayName;
            userNameLabel.Text = post.UserName;
            tweetTextLabel.Text = post.Text;
        }
    }
}