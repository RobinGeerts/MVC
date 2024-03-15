using Microsoft.AspNetCore.Mvc;
using Owledge.Models;
using Owledge.ViewModels;

namespace Owledge.Controllers
{
    public class InschrijvingController : Controller
    {

        private static Inschrijving inschrijving;

        public IActionResult Index()
        {
            //herleid de index naar de action Opleidingskeuze
            return RedirectToAction(nameof(OpleidingsKeuze));
        }

        public ActionResult OpleidingsKeuze()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Opleidingskeuze(KeuzeViewModel vm)
        {
            
            inschrijving = new Inschrijving();                                  //Dit is een instantie van een nieuwe inschrijving
            inschrijving.Opleiding = vm.Opleiding;                              //Dit is welke opleiding werd gekozen
            inschrijving.KeuzeVakken = new List<string>();                      //Dit is een lijstje waar 2 antwoorden in zitten 
            if (vm.Bedrijfskunde)
            {
                inschrijving.KeuzeVakken.Add("Inleiding tot bedrijfskunde");    //Als het is aangevinkt
            }
            if (vm.Scrum)
            {
                inschrijving.KeuzeVakken.Add("Scrum voor beginners");           //Als het is aangevinkt
            }
            
            return RedirectToAction(nameof(Persoonsgegevens));                  //Voert de action method Persoonsgegevens uit met meegestuurde inschrijving
        }

        public IActionResult Persoonsgegevens()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Persoonsgegevens(PersoonViewModel vm)
        {
            
            inschrijving.Voornaam = vm.Voornaam;                                //Dit geeft de waarde van de voornaam
            inschrijving.Familienaam = vm.Familienaam;                          //Dit geeft de waarde van de familienaam
            inschrijving.Roepnaam = vm.Roepnaam;                                //Dit is de roepnaam meestal mr of mvr
            inschrijving.Geboortedatum = vm.Geboortedatum;                      //Dit is de geboortedatum 
            inschrijving.Telefoonnummer = vm.Telefoonnummer;                    //dit is de telefoonnummer
            
            return RedirectToAction(nameof(Contactgegevens));                   //Voert de action method Contactgegevens uit met meegestuurde inschrijving
        }

        public IActionResult Contactgegevens()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contactgegevens(ContactViewModel vm)
        {
            
            inschrijving.Email = vm.Email;                                      //dit geeft de waarde van de email
            inschrijving.Straat = vm.Straat;                                    //dit geeft de waarde van de straat
            inschrijving.Huisnummer = vm.Huisnummer;                            //dit geeft de waarde van het huisnummer
            inschrijving.Postcode = vm.Postcode;                                //dit geeft de waarde van het postnummer
            inschrijving.Gemeente = vm.Gemeente;                                //dit geeft de waarde van de gemeente
            
            return RedirectToAction(nameof(Bevestiging));                       //Voert de action method Contactgegevens uit met meegestuurde inschrijving
        }

        public IActionResult Bevestiging()
        {
            
            BevestigingViewModel vm = new BevestigingViewModel();
            vm.Inschrijving = inschrijving;                                     //Toont alle ingevulde info van de inschrijving
            return View(vm);
        }
    }
}
