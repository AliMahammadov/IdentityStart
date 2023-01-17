using Pronia.Models.Base;

namespace Pronia.Models
{
    public class MehsulColor:BaseEntity
    {
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public Mehsul? Mehsul { get; set; }
        public Color? Color { get; set; }
    }
}
