using Pronia;
using Pronia.Models;

namespace Pronia.ViewModels.Home
{
    public class HomeVM
    {

        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
    }
}

