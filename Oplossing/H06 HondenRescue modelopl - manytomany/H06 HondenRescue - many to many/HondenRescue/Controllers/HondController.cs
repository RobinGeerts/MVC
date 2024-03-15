using HondenRescue.Data;
using HondenRescue.Models;
using HondenRescue.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HondenRescue.Controllers
{
    public class HondController : Controller
    {
        private readonly HRContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HondController(HRContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
           _hostingEnvironment = hostingEnvironment;
        }

		// READ-operaties
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



        public ActionResult EigenarenLijst()
        {
            var he = _context.HondEigenaren.Include(x => x.Hond).Include(x => x.Eigenaar).ToList();

            if (he == null) return NotFound();

            EigenarenHondenViewModel viewModel = new EigenarenHondenViewModel
            {
                EigenarenHonden = he
            };
            return View(viewModel);
        }

    }
}
