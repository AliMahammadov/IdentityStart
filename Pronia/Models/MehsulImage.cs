using Pronia.Models.Base;

namespace Pronia.Models
{
    public class MehsulImage: BaseEntity
    {
        public string ImageUrl { get; set; }
        public bool? IsCover { get; set; }
        public int ProductId { get; set; }
        public Mehsul? Mehsul { get; set; }
    }
}
