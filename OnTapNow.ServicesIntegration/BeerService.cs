using OnTapNow.Business;
using OnTapNow.Services;

namespace OnTapNow.ServicesIntegration
{
	public class BeerService : IBeerService
	{
		private readonly IBeerServices _vendorABeerServices;

		public BeerService()
		{
			_vendorABeerServices = new VendorABeerService();
		}

		public BeersResponse GetBeers()
		{
			return _vendorABeerServices.GetBeers();
		}

		public BeerResponse GetBeer(string id)
		{
			return _vendorABeerServices.GetBeer(id);
		}

		public BeerResponse AddBeer(Beer beer)
		{
			return _vendorABeerServices.AddBeer(beer);
		}

		public BeerResponse UpdateBeer(Beer beer)
		{
			return _vendorABeerServices.UpdateBeer(beer);
		}

		public BaseResponse DeleteBeer(string id)
		{
			return _vendorABeerServices.DeleteBeer(id);
		}
	}
}
