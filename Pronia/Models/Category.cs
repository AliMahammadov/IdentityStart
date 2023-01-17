using System.ComponentModel.DataAnnotations;

namespace Pronia.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MinLength(2, ErrorMessage = "uzuluq 2 ola bilmez"), MaxLength(40, ErrorMessage = "uzuluq 40 ola bilmez")]
        public string Name { get; set; }
        //public string Image { get; set; }    //bu
        public string ImgUrl { get; set; }
        public List< Mehsul>? mehsuls { get; set; }
    }
}
