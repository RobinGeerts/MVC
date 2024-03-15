using System.ComponentModel.DataAnnotations;

namespace HondenRescue.Models
{
    public enum Geslacht {Vrouwtje, Mannetje}
    public class Hond
    {
        public int HondId { get; set; }

		[Required]
		public string Naam { get; set; } = default!;

		// Wijzigen van ? naar default (required)
		//  NNA
		[Required]
        [DataType(DataType.Date)]
        public DateTime Geboortedatum { get; set; }

        public Geslacht Geslacht { get; set; }

        public string? Opmerkingen {get; set; } = default!;
        
        // NA
        public DateTime? LaatsteVaccinatieDatum { get; set; } = default!;

        public string FotoNaam { get; set; } = default!;

        //  NNA
        [Required]
        public bool Gechipt { get; set;} = default!;

	}
}
