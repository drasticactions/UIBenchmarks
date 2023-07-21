using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIBenchmarks.Models;

public class SocialMediaPost
{
    public string? UserName { get; set; }
    
    public string? DisplayName { get; set; }

    public byte[]? ProfileImageBytes { get; set; }

    public string? ProfileImageUrl { get; set; }

    public string? Text { get; set; }
}
