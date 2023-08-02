namespace UIBenchmarks.Models;

public class FeedPost
{
    public Post Post { get; set; }
    
    public RepostReason? Reason { get; set; }
    
    public PostReply? Reply { get; set; }
}

public class PostReply
{
    public Post? Parent { get; set; }
    
    public Post? Root { get; set; } 
}

public class RepostReason
{
    public Author By { get; set; }
}

public class Post
{
    public string Text { get; set; }
    
    public Author Author { get; set; }
    
    public Embed Embed { get; set; }
}

public class Author
{
    public string Name { get; set; }
    
    public string Avatar { get; set; }
}

public class Embed
{
    public string Type { get; set; }
}

public class ExternalEmbed : Embed
{
    public string Thumb { get; set; }
    
    public string Title { get; set; }
    
    public string Uri { get; set; }
    
    public string Description { get; set; }
}

public class PostImageEmbed : Embed
{
    public ImageEmbed ImageEmbed { get; set; }

    public PostEmbed PostEmbed { get; set; }
}

public class ImageEmbed : Embed
{
    public List<string> Urls { get; set; }
}

public class PostEmbed : Embed
{
    public Post Post { get; set; }
}
