using Microsoft.AspNetCore.Mvc;
using Owledge.Models;
using Owledge.ViewModels;

namespace Owledge.Controllers
{
    public class InschrijvingController : Controller
    {
        //Inschrijving die over de verschillende stappen uitgebreid zal worden
        private static Inschrijving inschrijving; 

        public IActionResult Index()
        {
            //Voert de action method Opleidingskeuze uit
            return RedirectToAction(nameof(Opleidingskeuze));
        }

        public IActionResult Opleidingskeuze()
        {
            //Toon View met formulier
            return View();
        }

        [HttpPost]
        public IActionResult Opleidingskeuze(OpleidingskeuzeViewModel vm)
        {
            //Gegevens ophalen uit ViewModel en inschrijving instantie opvullen
            inschrijving = new Inschrijving();
            inschrijving.Opleiding = vm.Opleiding;
            inschrijving.KeuzeVakken = new List<string>();
            if (vm.InleidingTotBedrijfskunde)
            {
                inschrijving.KeuzeVakken.Add("Inleiding tot bedrijfskunde");
            }
            if (vm.ScrumVoorBeginners)
            {
                inschrijving.KeuzeVakken.Add("Scrum voor beginners");
            }
            //Voert de action method Persoonsgegevens uit met meegestuurde inschrijving
            return RedirectToAction(nameof(Persoonsgegevens));
        }

        public IActionResult Persoonsgegevens()
        {
            //Toon View met formulier
            return View();
        }

        [HttpPost]
        public IActionResult Persoonsgegevens(PersoonsgegevensViewModel vm)
        {
            //Gegevens ophalen uit ViewModel en inschrijving instantie aanvullen
            inschrijving.Voornaam = vm.Voornaam;
            inschrijving.Familienaam = vm.Familienaam;
            inschrijving.Roepnaam = vm.Roepnaam;
            inschrijving.Geboortedatum = vm.Geboortedatum;
            inschrijving.Telefoonnummer = vm.Telefoonnummer;
            //Voert de action method Contactgegevens uit met meegestuurde inschrijving
            return RedirectToAction(nameof(Contactgegevens));
        }

            public IActionResult Contactgegevens()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contactgegevens(ContactgegevensViewModel vm)
        {
            //Gegevens ophalen uit ViewModel en inschrijving instantie aanvullen
            inschrijving.Email = vm.Email;
            inschrijving.Straat = vm.Straat;
            inschrijving.Huisnummer = vm.Huisnummer;
            inschrijving.Postcode = vm.Postcode;
            inschrijving.Gemeente = vm.Gemeente;
            //Voert de action method Contactgegevens uit met meegestuurde inschrijving
            return RedirectToAction(nameof(Bevestiging));
        }

        public IActionResult Bevestiging()
        {
            //Vul Viewmodel op
            BevestigingViewModel vm = new BevestigingViewModel();
            vm.Inschrijving = inschrijving;
            return View(vm);
        }
    }
}
