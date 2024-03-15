using Owledge.Models;
using System.ComponentModel.DataAnnotations;

namespace Owledge.ViewModels
{
    public class OpleidingskeuzeViewModel
    {
        [Required]
        public string Opleiding { get; set; }
        public bool InleidingTotBedrijfskunde { get; set; }

        public bool ScrumVoorBeginners { get; set; }

    }
}
