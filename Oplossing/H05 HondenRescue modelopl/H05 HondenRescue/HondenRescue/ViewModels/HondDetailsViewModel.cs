using HondenRescue.Models;

namespace HondenRescue.ViewModels
{
    public class HondDetailsViewModel
    {
        public int HondId { get; set; }

        public string Naam { get; set; } = default!;

        public DateTime? Geboortedatum { get; set; }

        public Geslacht Geslacht { get; set; }

        public string Opmerkingen { get; set; } = default!;
    }
}
