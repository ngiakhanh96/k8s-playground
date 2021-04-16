using System.Collections.Generic;

namespace HypermediaAPI.Models
{
    public interface IWrapper
    {
        List<Link> Links { get; set; }
    }
}