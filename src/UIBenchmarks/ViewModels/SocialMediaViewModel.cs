using System.Collections.ObjectModel;
using Bogus;
using Bogus.DataSets;
using Drastic.ViewModels;
using UIBenchmarks.Models;
using UIBenchmarks.Tools;

namespace UIBenchmarks.ViewModels;

public class SocialMediaViewModel : BaseViewModel
{
    private Randomizer random;
    private Lorem lorem;
    
    public SocialMediaViewModel(IServiceProvider services) : base(services)
    {
        this.random = new Bogus.Randomizer();
        this.lorem = new Bogus.DataSets.Lorem("en");
        this.Posts = new InfiniteScrollCollection<FeedPost>(this.Dispatcher);
        this.Posts.OnLoadMore = async () =>
        {
            var list = new List<FeedPost>();
            for (var i = 0; i < 100; i++)
            {
                list.Add(this.GenerateFeedPost());
            }
            return list;
        };
    }
    
    private FeedPost GenerateFeedPost()
    {
        var post = new FeedPost();
        post.Post = this.GeneratePost();
        if (post.Post.Embed is not null)
        {
            
        }
        return post;
    }

    private Post GeneratePost()
    {
        var post = new Post();
        post.Text = this.lorem.Sentences(this.random.Number(1, 10));
        post.Author = this.GenerateAuthor();
        var embedType = this.random.Enum<EmbedType>();
        switch (embedType)
        {
            case EmbedType.Image:
                post.Embed = this.GenerateImageEmbed();
                break;
            case EmbedType.External:
                post.Embed = this.GenerateExternalEmbed();
                break;
            case EmbedType.Post:
                post.Embed = this.GeneratePostEmbed();
                break;
            case EmbedType.PostImage:
                post.Embed = this.GeneratePostImageEmbed();
                break;
        }
        return post;
    }

    private ExternalEmbed GenerateExternalEmbed()
    {
        var embed = new ExternalEmbed();
        embed.Thumb = $"https://picsum.photos/{this.random.Number(200, 400)}/{this.random.Number(200, 400)}";
        embed.Title = this.lorem.Sentence();
        embed.Uri = $"https://picsum.photos/{this.random.Number(200, 400)}/{this.random.Number(200, 400)}";
        embed.Description = this.lorem.Sentences(this.random.Number(1, 3));
        return embed;
    }
    
    private PostImageEmbed GeneratePostImageEmbed()
    {
        var embed = new PostImageEmbed();
        embed.ImageEmbed = this.GenerateImageEmbed();
        embed.PostEmbed = this.GeneratePostEmbed();
        return embed;
    }
    
    private PostEmbed GeneratePostEmbed()
    {
        var embed = new PostEmbed();
        embed.Post = this.GeneratePost();
        return embed;
    }
    
    private ImageEmbed GenerateImageEmbed()
    {
        var embed = new ImageEmbed();
        embed.Urls = new List<string>();
        for (var i = 0; i < this.random.Number(1, 4); i++)
        {
            embed.Urls.Add($"https://picsum.photos/200/200");
            //embed.Urls.Add($"https://picsum.photos/{this.random.Number(200, 400)}/{this.random.Number(200, 400)}");
        }
        return embed;
    }

    private Author GenerateAuthor()
    {
        var author = new Author();
        author.Avatar = "https://picsum.photos/60/60";
        author.Name = $"{lorem.Word()} {lorem.Word()}";
        return author;
    }
    
    public InfiniteScrollCollection<FeedPost> Posts { get; }

    public override async Task OnLoad()
    {
        await base.OnLoad();
        await this.Posts.LoadMoreAsync();
    }

    public enum EmbedType
    {
        None,
        Image,
        External,
        Post,
        PostImage,
    }
}