using System.Collections.Generic;

namespace HypermediaAPI.Models
{
    public interface ILinkProfile
    {
        List<Link> Links { get; init; }
    }
}
