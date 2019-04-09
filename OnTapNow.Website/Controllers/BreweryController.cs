using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using OnTapNow.Business;
using OnTapNow.Website.Models;
using OnTapNow.ServicesIntegration;

namespace OnTapNow.Website.Controllers
{
	public class BreweryController : Controller
	{
		private readonly IBreweryService _breweryService;

		public BreweryController()
		{
			_breweryService = new BreweryService();
		}

		public async Task<ActionResult> Index()
		{
			var response = await _breweryService.GetBreweries();

			var model = new BreweriesViewModel()
			{
				Breweries = response.Breweries
			};

			return View(model);
		}

		public async Task<ActionResult> Brewery(string id)
		{
			var response = await _breweryService.GetBrewery(id);

			var model = new BreweryViewModel
			{
				Brewery = response.Brewery
			};

			return View(model);
		}

		public async Task<ActionResult> GetBrewery(string name)
		{
			var response = await _breweryService.GetBreweries();

			var brewery = response.Breweries.FirstOrDefault(b => b.Name == name) ?? new Brewery
			{
				Name = name,
				Address = new Address()
			};

			var model = new BreweryViewModel
			{
				Brewery = brewery
			};

			return View("Brewery", model);
		}
	}
}