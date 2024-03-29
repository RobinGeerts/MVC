﻿
namespace _09_01_InterimKantoor.ViewModels
{
    public class JobCreateViewModel
    {
        public string Omschrijving { get; set; } = default!;
        [Required]
        public DateTime StartDatum { get; set; }
        [Required]
        public DateTime EindDatum { get; set; }
        [Required]
        public string Locatie { get; set; } = default!;
        [Required]
        public bool IsWerkschoenen { get; set; }
        [Required]
        public bool IsBadge { get; set; }
        [Required]
        public bool IsKleding { get; set; }
        [Required]
        public int AantalPlaatsen { get; set; }
    }
}
