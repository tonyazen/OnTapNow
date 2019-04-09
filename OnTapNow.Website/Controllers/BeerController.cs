using System.Web.Mvc;
using OnTapNow.ServicesIntegration;
using OnTapNow.Website.Models;

namespace OnTapNow.Website.Controllers
{
	public class BeerController : Controller
	{
		private readonly IBeerService _beerServices;

		public BeerController()
		{
			_beerServices = new BeerService();
		}

		[HttpGet]
		public ActionResult Beer(string id)
		{
			var response = _beerServices.GetBeer(id);

			if (response.Success)
			{
				var model = new BeerViewModel
				{
					Beer = response.Beer
				};

				return View(model);
			}

			return View("Error");
		}

		[HttpGet]
		public ActionResult Index()
		{
			var response = _beerServices.GetBeers();

			if (response.Success)
			{
				var model = new BeersViewModel
				{
					Beers = response.Beers
				};

				return View(model);
			}

			return View("Error");
		}

		[HttpGet]
		public ActionResult AddBeer()
		{
			var model = new BeerViewModel();
			return View(model);
		}

		[HttpPost]
		public ActionResult AddBeer(BeerViewModel model)
		{
			var response = _beerServices.AddBeer(model.Beer);

			if (response.Success)
			{
				var newBeerModel = new BeerViewModel
				{
					Beer = response.Beer
				};

				return RedirectToAction("Beer", new { id = newBeerModel.Beer.Id });
			}

			return View("Error");
		}

		[HttpGet]
		public ActionResult UpdateBeer(string id)
		{
			var response = _beerServices.GetBeer(id);

			if (response.Success)
			{
				var model = new BeerViewModel
				{
					Beer = response.Beer
				};

				return View(model);
			}

			return View("Error");
		}

		[HttpPost]
		public ActionResult UpdateBeer(BeerViewModel model)
		{
			var response = _beerServices.UpdateBeer(model.Beer);

			if (response.Success)
			{
				var updateBeerModel = new BeerViewModel
				{
					Beer = response.Beer
				};

				return RedirectToAction("Beer", new { id = updateBeerModel.Beer.Id });
			}

			return View("Error");
		}

		[HttpPost]
		public ActionResult DeleteBeer(string id)
		{
			var response = _beerServices.DeleteBeer(id);

			if (response.Success)
			{
				return RedirectToAction("Index", "Home");
			}

			return View("Error");
		}
	}
}