using _4Tune.Models;
using _4Tune.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _4Tune.Controllers
{
    public class AutoController : Controller
    {
        public List<Auto> AlleAutos = new List<Auto>()
        {
            new Auto() { Id = 1, Merk = "Audi", Model = "A1 Sportback", Bouwjaar = 2023, Brandstofefficientie = 5.5, Prijs = 17855m, Afbeelding = "audi-a1-sportback.jpg" },
            new Auto() { Id = 2, Merk = "Audi", Model = "A3 Sportback", Bouwjaar = 2022, Brandstofefficientie = 6.7, Prijs = 21675m, Afbeelding = "audi-a3-sportback.jpg" },
            new Auto() { Id = 3, Merk = "Renault", Model = "Kangoo", Bouwjaar = 2020, Brandstofefficientie = 5.9, Prijs = 16500m, Afbeelding = "renault-kangoo.jpg" },
            new Auto() { Id = 4, Merk = "Renault", Model = "Twigo", Bouwjaar = 2017, Brandstofefficientie = 4.7, Prijs = 5500m, Afbeelding = "renault-twigo.jpg" },
            new Auto() { Id = 5, Merk = "Renault", Model = "Clio", Bouwjaar = 2014, Brandstofefficientie = 4.1, Prijs = 6999m, Afbeelding = "renault-clio.jpg" },
            new Auto() { Id = 6, Merk = "Opel", Model = "Mokka", Bouwjaar = 2020, Brandstofefficientie = 7.9, Prijs = 22499m, Afbeelding = "opel-mokka.jpg" },
            new Auto() { Id = 7, Merk = "Opel", Model = "Astra", Bouwjaar = 2017, Brandstofefficientie = 5.9, Prijs = 14599m, Afbeelding = "opel-astra.jpg" },
            new Auto() { Id = 8, Merk = "Opel", Model = "Corsa", Bouwjaar = 2009, Brandstofefficientie = 3.6, Prijs = 5750m, Afbeelding = "opel-corsa.jpg" }
        };

        public List<Auto> AudiAutos;
        public List<Auto> RenaultAutos;
        public List<Auto> OpelAutos;
        public List<Auto> PeugeotAutos;

        public IActionResult Index()
        {
            AudiAutos = new List<Auto>();
            RenaultAutos = new List<Auto>();
            OpelAutos = new List<Auto>();
            PeugeotAutos = new List<Auto>();

            foreach (Auto auto in AlleAutos)
            {
                if (auto.Merk == "Audi")
                    AudiAutos.Add(auto);
                if (auto.Merk == "Renault")
                    RenaultAutos.Add(auto);
                if (auto.Merk == "Opel")
                    OpelAutos.Add(auto);
                if (auto.Merk == "Peugeot")
                    PeugeotAutos.Add(auto);
            }

            AutoOverzichtViewModel vm  = new AutoOverzichtViewModel();
            vm.AudiAutos = AudiAutos;
            vm.RenaultAutos = RenaultAutos;
            vm.OpelAutos = OpelAutos;
            vm.PeugeotAutos= PeugeotAutos;

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            AutoDetailsViewModel vm = new AutoDetailsViewModel();

            foreach (Auto auto in AlleAutos)
            {
                if (auto.Id == id)
                    vm.Auto = auto;
            }

            return View(vm);
        }
    }
}
