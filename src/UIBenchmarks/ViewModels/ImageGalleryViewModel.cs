using Drastic.ViewModels;
using UIBenchmarks.Models;

namespace UIBenchmarks.ViewModels;

public class ImageGalleryViewModel : BaseViewModel
{
    public ImageGalleryViewModel(IServiceProvider services)
        : base(services)
    {
        var count = 0;
        for(var i = 0; i < 1000; ++i)
        {
            count = count < 4 ? count + 1 : 1;
            var urls  = new List<string>();
            switch (count)
            {
                case 1:
                    urls.Add("https://picsum.photos/200/300");
                    break;
                case 2:
                    urls.Add("https://picsum.photos/200/300");
                    urls.Add("https://picsum.photos/200/300");
                    break;
                case 3:
                    urls.Add("https://picsum.photos/200/300");
                    urls.Add("https://picsum.photos/200/300");
                    urls.Add("https://picsum.photos/200/300");
                    break;
                case 4:
                    urls.Add("https://picsum.photos/200/300");
                    urls.Add("https://picsum.photos/200/300");
                    urls.Add("https://picsum.photos/200/300");
                    urls.Add("https://picsum.photos/200/300");
                    break;
            }
            
            this.Images.Add(new ImageEmbed() { Urls = urls });
        }
    }
    
    public List<ImageEmbed> Images { get; } = new List<ImageEmbed>();
}