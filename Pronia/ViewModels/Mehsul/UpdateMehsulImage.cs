namespace Pronia.ViewModels.Mehsul
{
    public class UpdateMehsulImage
    {
        public IFormFile? CoverImage { get; set; }
        public IFormFile? HoverImage { get; set; }
        public IEnumerable<IFormFile>? OtherImages { get; set; }
        //public IEnumerable<ProductImage> ProductImages { get; set; }
        public IEnumerable<int> ImageIds { get; set; }
    }
}
