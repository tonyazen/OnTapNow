using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnTapNow.Business;

namespace OnTapNow.ServicesIntegration
{
	public interface IBeerService
	{
		BeersResponse GetBeers();
		BeerResponse GetBeer(string id);
		BeerResponse AddBeer(Beer beer);
		BeerResponse UpdateBeer(Beer beer);
		BaseResponse DeleteBeer(string id);
	}
}
