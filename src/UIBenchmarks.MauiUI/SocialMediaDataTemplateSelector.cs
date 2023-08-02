using UIBenchmarks.Models;

namespace UIBenchmarks.MauiUI;

public class SocialMediaDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate? PostTemplate { get; set; }
    
    public DataTemplate? ImagePostTemplate { get; set; }
    
    public DataTemplate? ExternalPostTemplate { get; set; }
    
    public DataTemplate? EmbedPostTemplate { get; set; }
    
    public DataTemplate? EmbedPostImageTemplate { get; set; }
    
    public DataTemplate? EmbedPostExternalTemplate { get; set; }
    
    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        if (item is FeedPost post)
        {
            if (post.Post.Embed is ImageEmbed)
            {
                return this.ImagePostTemplate;
            }
            
            if (post.Post.Embed is ExternalEmbed)
            {
                return this.ExternalPostTemplate;
            }
            
            if (post.Post.Embed is PostEmbed emb)
            {
                if (emb.Post.Embed is ImageEmbed)
                {
                    return this.EmbedPostImageTemplate;
                }
                
                if (emb.Post.Embed is ExternalEmbed)
                {
                    return this.EmbedPostExternalTemplate;
                }
                
                return this.EmbedPostTemplate;
            }
        }
        
        return this.PostTemplate;
    }
}