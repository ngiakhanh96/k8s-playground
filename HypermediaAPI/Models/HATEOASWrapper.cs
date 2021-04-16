using System.Collections.Generic;

namespace HypermediaAPI.Models
{
    public class HATEOASWrapper : IWrapper
    {
        public HATEOASWrapper()
        {
        }

        public object Result { get; set; }
        public List<Link> Links { get; set; }
    }
}
