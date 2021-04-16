using System.Collections.Generic;

namespace HypermediaAPI.Models
{
    public class ShoppingLinkProfile : ILinkProfile
    {
        public List<Link> Links { get; init; }

        public ShoppingLinkProfile()
        {
            Links = new()
            {
                new()
                {
                    Rel = "create",
                    Href = "shopping/create"
                },
                new()
                {
                    Rel = "update",
                    Href = "shopping/update"
                }
            };
        }
    }
}
