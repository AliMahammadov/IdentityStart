using Microsoft.VisualStudio.Web.CodeGeneration.Utils;
using Pronia.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Pronia.Models
{
    public class Mehsul:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        [Range(0.0, Double.MaxValue)]
        public double CostPrice { get; set; }
        [Range(0.0, Double.MaxValue)]
        public double SellPrice { get; set; }
        [Range(0, 100)]
        public int Discount { get; set; }
        //public int StockCount { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<MehsulColor>? MehsulColors { get; set; }
        public ICollection<MehsulSize>? MehsulSize { get; set; }
        public ICollection<MehsulImage>? MehsulImage { get; set; }
        public MehsulInformation? MehsulInformation { get; set; }

    }
}
