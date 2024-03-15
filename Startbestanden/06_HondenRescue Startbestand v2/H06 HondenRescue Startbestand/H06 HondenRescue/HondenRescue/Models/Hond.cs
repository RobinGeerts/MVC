using System.ComponentModel.DataAnnotations;

namespace HondenRescue.Models
{
    public enum Geslacht {Vrouwtje, Mannetje}
    public class Hond
    {
        public int HondId { get; set; }

		public string Naam { get; set; } = default!;

        [DataType(DataType.Date)]
        public DateTime Geboortedatum { get; set; }

        public Geslacht Geslacht { get; set; }

        public string? Opmerkingen {get; set; } = default!;
        
        public DateTime LaatsteVaccinatieDatum { get; set; } = default!;

        public bool Gechipt { get; set;} = default!;

    }
}
