using System.Collections.Generic;

namespace Drin.Core
{
    public class Category : BaseEntity
    {
        public Category(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
