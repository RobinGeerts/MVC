using HondenRescue.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HondenRescue.ViewModels
{
	public class HondCreateViewModel
	{
		public int HondId { get; set; }

		public string Naam { get; set; } = default!;

        [DataType(DataType.Date)]
        public DateTime Geboortedatum { get; set; }

		//public Geslacht Geslacht { get; set; }

		[Display(Name = "Geslacht")]
        public string SelectedGeslacht { get; set; } = default!;

        public IEnumerable<SelectListItem>? Geslacht { get; set; }

        //public string Opmerkingen { get; set; } = default!;

		//public DateTime? LaatsteVaccinatieDatum { get; set; } = default!;

		public bool Gechipt { get; set; } = default!;

        public IFormFile Foto { get; set; } = default!;

        //Tijdens create-get is dit nog leeg, vanaf post is dit gevuld
        public string? FotoNaam { get; set; } = default!;


        //Dropdown elementen
        public SelectList Eigenaren { get; set; } = default!;

        public int EigenaarId { get; set; } = default!;
    }
}
