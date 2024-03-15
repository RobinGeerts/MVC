using HondenRescue.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HondenRescue.ViewModels
{
	public class HondEditViewModel
	{
		public int HondId { get; set; }

		public string Naam { get; set; } = default!;

        [DataType(DataType.Date)]
        public DateTime Geboortedatum { get; set; }

        [Display(Name = "Geslacht")]
        public string SelectedGeslacht { get; set; } = default!;

        public IEnumerable<SelectListItem>? Geslacht { get; set; }

        //public string Opmerkingen { get; set; } = default!;

		//public DateTime? LaatsteVaccinatieDatum { get; set; } = default!;

		public bool Gechipt { get; set; } = default!;
	}
}
