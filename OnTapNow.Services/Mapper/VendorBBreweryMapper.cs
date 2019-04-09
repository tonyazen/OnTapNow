using System.Collections.Generic;
using System.Linq;
using OnTapNow.Business;
using OnTapNow.Services.Models;

namespace OnTapNow.Services.Mapper
{
	public class VendorBBreweryMapper
	{
		public Brewery MapBrewery(VendorBBrewery brewery)
		{
			return new Brewery
			{
				Id = brewery.Id,
				Name = brewery.Name,
				Address = new Business.Address
				{
					Street1 = brewery.Address.Street1,
					Street2 = brewery.Address.Street2,
					City = brewery.Address.City,
					StateCode = brewery.Address.StateCode,
					ZipCode = brewery.Address.ZipCode
				}
			};
		}

		public List<Brewery> MapBreweries(VendorBBrewery[] breweries)
		{
			return breweries.Select(MapBrewery).ToList();
		}
	}
}
