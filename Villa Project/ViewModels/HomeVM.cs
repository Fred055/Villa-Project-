using Villa_Project.Models;

namespace Villa_Project.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public IEnumerable<VillaVM> Villas { get; set; }
        public IEnumerable<VillaSingleVM> VillaSingle { get; set; }
    }
}
