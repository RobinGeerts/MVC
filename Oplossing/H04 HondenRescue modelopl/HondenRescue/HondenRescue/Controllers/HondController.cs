using HondenRescue.Data;
using HondenRescue.Models;
using HondenRescue.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HondenRescue.Controllers
{
    public class HondController : Controller
    {
        private readonly HRContext _context;

        public HondController(HRContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HondListViewModel viewModel = new HondListViewModel();
            viewModel.Honden = _context.Honden.ToList();
            return View(viewModel);
        }

        public IActionResult Bekijken(int id)
        {
            Hond? hond = _context.Honden.Where(d => d.HondId == id).FirstOrDefault();

            if (hond == null) return RedirectToAction("Index");

            HondDetailsViewModel vm = new HondDetailsViewModel()
            {
                HondId = id,
                Naam = hond.Naam,
                Geboortedatum = hond.Geboortedatum,
                Geslacht = hond.Geslacht
            };

            return View(vm);
        }

    }
}
