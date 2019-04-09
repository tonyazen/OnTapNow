using OnTapNow.Business;

namespace OnTapNow.Services
{
	public interface IBeerServices
	{
		BeersResponse GetBeers();
		BeerResponse GetBeer(string id);
		BeerResponse AddBeer(Beer beer);
		BeerResponse UpdateBeer(Beer beer);
		BaseResponse DeleteBeer(string id);
	}
}
