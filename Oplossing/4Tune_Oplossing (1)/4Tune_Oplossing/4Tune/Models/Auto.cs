using System.ComponentModel.DataAnnotations;

namespace _4Tune.Models
{
    public class Auto
    {
        public int Id { get; set; }
        public string Merk { get; set; }
        public string Model { get; set; }
        public int Bouwjaar { get; set; }
        public double Brandstofefficientie { get; set; }
        [DataType(DataType.Currency)]
        public Decimal Prijs { get; set; }
        public string Afbeelding { get; set; }
    }
}
