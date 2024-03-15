﻿

namespace _09_01_InterimKantoor.Controllers
{

    public class HomeController : Controller
    {
        private readonly IUnitOfWork _context;

        public HomeController(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
                var jobs =  await _context.JobRepository.GetAllAsync();

            var viewModelList = new List<JobDetailsViewModel>();

                foreach (var job in jobs)
                {
                var klantjobs = await _context.KlantJobRepository.GetAllAsync();
                    int aantalBezettePlaatsen = klantjobs.Count(kj => kj.JobId == job.Id);
                    var viewModel = new JobDetailsViewModel
                    {
                        Id= job.Id,
                        Omschrijving=job.Omschrijving,
                        StartDatum=job.StartDatum,
                        EindDatum=job.EindDatum,
                        IsBadge=job.IsBadge,
                        IsKleding=job.IsKleding,
                        IsWerkschoenen=job.IsWerkschoenen,
                        Locatie=job.Locatie,
                        AantalPlaatsen=job.AantalPlaatsen,
                        VrijePlaatsen = job.AantalPlaatsen-aantalBezettePlaatsen
                    };

                    viewModelList.Add(viewModel);
                }

                return View(viewModelList);
            }
        }


}
