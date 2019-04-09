using System.Threading.Tasks;
using OnTapNow.Business;

namespace OnTapNow.Services
{
	public interface IBreweryServices
	{
		Task<BreweriesResponse> GetBreweries();
		Task<BreweryResponse> GetBrewery(string id);
	}
}
