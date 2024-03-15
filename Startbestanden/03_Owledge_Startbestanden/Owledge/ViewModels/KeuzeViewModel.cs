using System.ComponentModel.DataAnnotations;

namespace Owledge.ViewModels
{
    public class KeuzeViewModel
    {
        [Required]
        public string Opleiding { get; set; }   //Welke keuze opleiding is er gemaakt
        public bool Bedrijfskunde { get; set; } // Wel of niet gekozen voor bedrijfskunde
        public bool Scrum { get; set; }         //Wel of niet gekozen voor scrum
    }
}
