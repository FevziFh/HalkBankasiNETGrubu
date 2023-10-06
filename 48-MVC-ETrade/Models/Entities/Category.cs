using _48_MVC_ETrade.Models.Entities.BaseEntity;

namespace _48_MVC_ETrade.Models.Entities
{
    public class Category : BaseEntity.BaseEntity
    {
        public string Name { get; set; }
        public virtual IList<Product> Products { get; set; }
    }
}
