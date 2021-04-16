using HypermediaAPI.Database.Entities.Base;

namespace HypermediaAPI.Database.Entities
{
    public class ShoppingItem : Entity
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
