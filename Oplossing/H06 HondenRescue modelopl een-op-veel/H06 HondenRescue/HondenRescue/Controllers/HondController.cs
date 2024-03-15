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
            c.Eigenaren = new SelectList(_context.Eigenaren.ToList(), "EigenaarId", "VolledigeNaam");

            return View(c);
		}


        //Works
        public ActionResult EigenaarEnHunHonden()
        {
            var oh = _context.Eigenaren.Include(x => x.Honden).ToList();

            if (oh == null) return NotFound();

            EigenaarEnHunHondenViewModel viewModel = new EigenaarEnHunHondenViewModel
            {
                EigenaarMetHunHonden = oh
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HondCreateViewModel vm)
        {
            string selectedValue = vm.SelectedGeslacht;
                // Converteer de geselecteerde 'string' waarde naar de bijbehorende enumeratiewaarde
                if (selectedValue != null && !string.IsNullOrEmpty(selectedValue) && Enum.TryParse(selectedValue, out Geslacht geslacht))
                {
                    if (ModelState.IsValid)
                    {
                        string? _img = null;
                        if (vm.Foto != null && vm.Foto.Length > 0)
                        {
                            // Genereer een unieke bestandsnaam voor de foto
                            var uniekeBestandsnaam = Guid.NewGuid().ToString() + "_" + vm.Foto.FileName;

                            // Bepaal de map waarin je de foto wilt opslaan (bijv. wwwroot/images)
                            var opslagMap = Path.Combine(_hostingEnvironment.WebRootPath, "img");

                            // Maak de map aan als deze niet bestaat
                            Directory.CreateDirectory(opslagMap);

                            // Volledig pad naar het opgeslagen bestand
                            var filePath = Path.Combine(opslagMap, uniekeBestandsnaam);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                                await vm.Foto.CopyToAsync(stream);

                            _img = uniekeBestandsnaam.ToString();
                        }


                    await _context.Honden.AddAsync(new Hond()
                    {
                        HondId = vm.HondId,
                        Naam = vm.Naam,
                        Geboortedatum = vm.Geboortedatum,
                        Geslacht = geslacht,
                        Gechipt = vm.Gechipt,
                        FotoNaam = _img
                    });
                        _context.SaveChanges();
                    }

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
				Geboortedatum = hond.Geboortedatum,
				Geslacht = geslacht,
                SelectedGeslacht = ((Geslacht) hond.Geslacht).ToString()
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
                string selectedValue = vm.SelectedGeslacht;
                // Verkorte if met enum
                var geslacht = Enum.TryParse(selectedValue, out Geslacht parsedGeslacht) ? parsedGeslacht : default(Geslacht);

                try
				{
					Hond hond = new Hond()
					{
						HondId = vm.HondId,
						Naam = vm.Naam,
						Geboortedatum = vm.Geboortedatum,
						Geslacht = geslacht
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
            if (hond == null || id == 1)
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
