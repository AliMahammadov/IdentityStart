using Pronia.Models.Base;

namespace Pronia.Models
{
    public class MehsulInformation: BaseEntity
    {
        public string Shipping { get; set; }
        public string AboutReturnRequest { get; set; }
        public string Guarantee { get; set; }
        public int MehsulId { get; set; }
        public Mehsul? Mehsul { get; set; }
    }
}
