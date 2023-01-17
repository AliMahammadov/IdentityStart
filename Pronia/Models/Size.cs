using Pronia.Models.Base;

namespace Pronia.Models
{
    public class Size: BaseEntity
    {
        public string Name { get; set; }
        public ICollection<MehsulSize>? ProductSizes { get; set; }
    }
}
