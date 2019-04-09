using System.Threading.Tasks;
using OnTapNow.Business;

namespace OnTapNow.ServicesIntegration
{
	public interface IBreweryService
	{
		Task<BreweriesResponse> GetBreweries();
		Task<BreweryResponse> GetBrewery(string id);
	}
}
