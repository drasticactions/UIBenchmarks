using UIBenchmarks.Models;

namespace UIBenchmarks.MauiUI;

public class PostCodeBehindView : ContentView
{
    public static readonly BindableProperty EmbedProperty =
        BindableProperty.Create(nameof(Embed), typeof(FeedPost), typeof(PostCodeBehindView), default(FeedPost), propertyChanged: OnChanged);

    private static void OnChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
        var item = (PostCodeBehindView)bindable;
        item.UpdatePost();
    }

    public FeedPost? Embed {
        get { return (FeedPost)GetValue(EmbedProperty); }
        set { SetValue(EmbedProperty, value); }
    }

    public void UpdatePost()
    {
        if (this.Embed is null)
        {
            this.Content = null;
            return;
        }
        
        var grid = new Grid() { Margin = new Thickness(5, 2, 5, 2), ColumnSpacing = 5};
        grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = 60 });
        grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
        var avatar = new AvatarView() { Embed = new Uri(this.Embed.Post.Author.Avatar) };
        grid.Children.Add(avatar);
        Grid.SetColumn(avatar, 0);
        
        this.Content = grid;
    }
}