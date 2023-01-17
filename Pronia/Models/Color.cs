using Pronia.Models.Base;

namespace Pronia.Models
{
    public class Color:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<MehsulColor>? MehsulColor { get; set; }
    }
}
