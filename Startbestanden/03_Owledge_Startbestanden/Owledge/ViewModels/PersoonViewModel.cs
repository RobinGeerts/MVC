using System.ComponentModel.DataAnnotations;

namespace Owledge.ViewModels
{
    public class PersoonViewModel
    {
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public string Roepnaam { get; set; }



        [DataType(DataType.Date)]
        public DateTime Geboortedatum { get; set; }



        [DataType(DataType.PhoneNumber)]
        public string Telefoonnummer { get; set; }
    }
}
