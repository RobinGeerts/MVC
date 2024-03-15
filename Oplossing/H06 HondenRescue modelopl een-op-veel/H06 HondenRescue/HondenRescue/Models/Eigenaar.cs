using System.ComponentModel.DataAnnotations;

namespace HondenRescue.Models
{
    public class Eigenaar
    {
        public int EigenaarId { get; set; }

        [Required]
        public string Familienaam { get; set; } = default!;

        [Required]
        public string Voornaam { get; set; } = default!;

        public List<Hond> Honden { get; set; } = default!;

        public string VolledigeNaam
        {
            get { return Familienaam.ToUpper() + " " + Voornaam; }
        }

    }
}
