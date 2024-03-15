using System.ComponentModel.DataAnnotations;

namespace Owledge.Models
{
    public class Inschrijving
    {
        [Required]
        public string Opleiding { get; set; }
        public List<string> KeuzeVakken { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public string Roepnaam { get; set; }




        [DataType(DataType.Date)]
        public DateTime Geboortedatum { get; set; }




        public string Telefoonnummer { get; set; }
        public string Email { get; set; }
        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public int Postcode { get; set; }
        public string Gemeente { get; set; }
    }
}
