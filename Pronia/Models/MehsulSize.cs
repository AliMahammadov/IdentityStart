using Pronia.Models.Base;

namespace Pronia.Models
{
    public class MehsulSize: BaseEntity
    {
        public int MehsulId { get; set; }
        public int SizeId { get; set; }
        public Size? Size { get; set; }
        public Mehsul? Mehsul { get; set; }
    }
}
