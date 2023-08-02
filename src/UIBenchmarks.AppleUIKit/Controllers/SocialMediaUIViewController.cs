using UIBenchmarks.AppleUIKit.Views;
using UIBenchmarks.Models;

namespace UIBenchmarks.AppleUIKit.Controllers;

public class SocialMediaUIViewController : UIViewController
{
    private SocialMediaPost post;
    private SocialMediaView view;
    public SocialMediaUIViewController()
    {
        this.post = new SocialMediaPost()
        {
            UserName = "Username",
            DisplayName = "Display Name",
            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
        };
        
        View.BackgroundColor = UIColor.White;
        this.view = new SocialMediaView(post);
        View.AddSubview(this.view);

        this.view.TranslatesAutoresizingMaskIntoConstraints = false;

        this.view.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
        this.view.CenterYAnchor.ConstraintEqualTo(View.CenterYAnchor).Active = true;
        this.view.LeftAnchor.ConstraintEqualTo(View.LeftAnchor).Active = true;
        this.view.RightAnchor.ConstraintEqualTo(View.RightAnchor).Active = true;
    }
}