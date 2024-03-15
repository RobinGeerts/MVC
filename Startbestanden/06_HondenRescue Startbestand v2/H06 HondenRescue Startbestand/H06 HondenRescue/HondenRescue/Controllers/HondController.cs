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

        public HondController(HRContext context)
        {
            _context = context;
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

		////
		///CUD-operaties
		///
		public IActionResult Create()
		{
            // Dropdown van ennumeratie
            HondCreateViewModel c = new HondCreateViewModel();
            var geslacht = Enum.GetValues(typeof(Geslacht)).Cast<Geslacht>().Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            });

            //Properties
			c.Geslacht = geslacht;
			c.Geboortedatum = new DateTime(2002, 01, 01, 0, 0, 0);

            //Dropdown Eigenaren

            return View(c);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HondCreateViewModel vm)
        {
                    if (ModelState.IsValid)
                    {
                        await _context.Honden.AddAsync(new Hond()
                        {
                            HondId = vm.HondId,
                            Naam = vm.Naam,
                            Geboortedatum = vm.Geboortedatum,
                            Gechipt = vm.Gechipt,
                        });
                         _context.SaveChanges();

                        return RedirectToAction("Index");
                    }
                return View(vm);
		}



        public async Task<IActionResult> Edit(int id)
		{
            var hond = await _context.Honden.FindAsync(id);

			if (hond == null)
				return NotFound();

            var geslacht = Enum.GetValues(typeof(Geslacht)).Cast<Geslacht>().Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            });

            HondEditViewModel viewModel = new HondEditViewModel()
			{
				HondId = hond.HondId,
				Naam = hond.Naam,
				Geboortedatum = hond.Geboortedatum
			};

			return View(viewModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, HondEditViewModel vm)
		{
            if (id != vm.HondId)
				return NotFound();

            if (ModelState.IsValid )
			{
                try
				{
					Hond hond = new Hond()
					{
						HondId = vm.HondId,
						Naam = vm.Naam,
						Geboortedatum = vm.Geboortedatum
					};
					_context.Honden.Update(hond);
					_context.SaveChanges();

				}
				catch (DbUpdateConcurrencyException)
				{
					if (_context.Honden.Find(id) != null)
						return NotFound();
					else
					{
						throw;
					}

				}
				return RedirectToAction("Index");
			}
			return View(vm);
		}

        public async Task<IActionResult> Delete(int id)
        {
            var hond = await _context.Honden.FindAsync(id);
            if (hond == null)
                return NotFound();
            else
            {
                _context.Honden.Remove(hond);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
