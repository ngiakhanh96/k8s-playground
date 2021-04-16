using System.Collections.Generic;

namespace HypermediaAPI.Models
{
    public class ShoppingLinkItemProfile : ILinkProfile
    {
        public ShoppingLinkItemProfile(List<Link> links)
        {
            Links = links;
        }

        public List<Link> Links { get; init; }
    }
}
