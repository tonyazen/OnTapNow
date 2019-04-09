using System.Threading.Tasks;
using OnTapNow.Business;
using OnTapNow.Services;

namespace OnTapNow.ServicesIntegration
{
	public class BreweryService : IBreweryService
	{
		private readonly IBreweryServices _vendorBBreweryServices;

		public BreweryService()
		{
			_vendorBBreweryServices = new VendorBBreweryService();
		}

		public async Task<BreweriesResponse> GetBreweries()
		{
			return await _vendorBBreweryServices.GetBreweries();
		}

		public async Task<BreweryResponse> GetBrewery(string id)
		{
			return await _vendorBBreweryServices.GetBrewery(id);
		}
	}
}
