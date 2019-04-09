using OnTapNow.Business;

namespace OnTapNow.Website.Models
{
	public class BreweryViewModel
	{
		public Brewery Brewery { get; set; }
		public bool ShowAddress => Brewery.Address.Street1 != null;
	}
}