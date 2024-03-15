
namespace _09_01_InterimKantoor.ViewModels
{
    public class JobAssignViewModel
    {
        public string KlantId { get; set; } = default!;
        public int JobId { get; set; } 
        public List<SelectListItem> Klanten { get; set; } = new List<SelectListItem>();
        public string JobOmschrijving { get; set; } = default!;
    }
}
