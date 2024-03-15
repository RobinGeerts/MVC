using System.ComponentModel.DataAnnotations;

namespace Owledge.ViewModels
{
    public class ContactViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }



        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public int Postcode { get; set; }
        public string Gemeente { get; set; }
    }
}
