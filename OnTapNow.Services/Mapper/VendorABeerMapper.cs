using System;
using System.Collections.Generic;
using System.Linq;
using OnTapNow.Business;

namespace OnTapNow.Services.Mapper
{
	public class VendorABeerMapper
	{
		public BeerService.AddBeer MapServiceAddBeer(Beer newBeer)
		{
			return new BeerService.AddBeer
			{
				Abv = newBeer.Abv,
				Brewery = newBeer.Brewery.ToString(),
				Name = newBeer.Name,
				Style = MapBeerServiceStyle(newBeer.Style)
			};
		}

		public BeerService.Beer MapServiceBeer(Beer updateBeer)
		{
			return new BeerService.Beer
			{
				Id = Convert.ToInt32(updateBeer.Id),
				Abv = updateBeer.Abv,
				Brewery = updateBeer.Brewery.ToString(),
				Name = updateBeer.Name,
				Style = MapBeerServiceStyle(updateBeer.Style)
			};
		}

		public Beer MapBeer(BeerService.Beer beer)
		{
			return new Beer
			{
				Id = beer.Id.ToString(),
				Abv = beer.Abv,
				Brewery = new Brewery
				{
					Name = beer.Brewery
				},
				Name = beer.Name,
				Style = MapOnTapNowBeerStyle(beer.Style)
			};
		}

		public List<Beer> MapBeers(BeerService.Beer[] beers)
		{
			return beers.Select(MapBeer).ToList();
		}

		private BeerService.Style MapBeerServiceStyle(BeerStyle style)
		{
			switch (style)
			{
				case BeerStyle.Ale:
					return BeerService.Style.Ale; // Could add using BeerService... sometimes nice to see this more obviously differentiated
				case BeerStyle.AmericanPaleAle:
					return BeerService.Style.AmericanPaleAle;
				case BeerStyle.BarleyWine:
					return BeerService.Style.BarleyWine;
				case BeerStyle.Bitter:
					return BeerService.Style.Bitter;
				case BeerStyle.Boch:
					return BeerService.Style.Boch;
				case BeerStyle.BrownAle:
					return BeerService.Style.BrownAle;
				case BeerStyle.CreamAle:
					return BeerService.Style.CreamAle;
				case BeerStyle.Dubbel:
					return BeerService.Style.Dubbel;
				case BeerStyle.Dunkel:
					return BeerService.Style.Dunkel;
				case BeerStyle.Gose:
					return BeerService.Style.Gose;
				case BeerStyle.IndianPaleAle:
					return BeerService.Style.IPA; // Casting may not work well since naming conventions don't always match up
				case BeerStyle.Kolsch:
					return BeerService.Style.Kolsch;
				case BeerStyle.Lager:
					return BeerService.Style.Lager;
				case BeerStyle.Lambic:
					return BeerService.Style.Lambic;
				case BeerStyle.Marzen:
					return BeerService.Style.Other; // Another example where casting won't work. Could just use default below
				case BeerStyle.MidAle:
					return BeerService.Style.Other;
				case BeerStyle.OldAle:
					return BeerService.Style.Other;
				case BeerStyle.PaleAle:
					return BeerService.Style.PaleAle;
				case BeerStyle.PaleLager:
					return BeerService.Style.Other;
				case BeerStyle.Pilsner:
					return BeerService.Style.Pilsner;
				case BeerStyle.Porter:
					return BeerService.Style.Porter;
				case BeerStyle.Red:
					return BeerService.Style.Other;
				case BeerStyle.Saison:
					return BeerService.Style.Saison;
				case BeerStyle.ScotchAle:
					return BeerService.Style.ScotchAle;
				case BeerStyle.Stout:
					return BeerService.Style.Stout;
				case BeerStyle.Tripel:
					return BeerService.Style.Tripel;
				case BeerStyle.Wheat:
					return BeerService.Style.Wheat;
				default:
					return BeerService.Style.Other;
			}
		}

		private BeerStyle MapOnTapNowBeerStyle(BeerService.Style style)
		{
			switch (style)
			{
				case BeerService.Style.Ale:
					return BeerStyle.Ale;
				case BeerService.Style.AmericanPaleAle:
					return BeerStyle.AmericanPaleAle;
				case BeerService.Style.BarleyWine:
					return BeerStyle.BarleyWine;
				case BeerService.Style.Bitter:
					return BeerStyle.Bitter;
				case BeerService.Style.Boch:
					return BeerStyle.Boch;
				case BeerService.Style.BrownAle:
					return BeerStyle.BrownAle;
				case BeerService.Style.CreamAle:
					return BeerStyle.CreamAle;
				case BeerService.Style.Dubbel:
					return BeerStyle.Dubbel;
				case BeerService.Style.Dunkel:
					return BeerStyle.Dunkel;
				case BeerService.Style.Gose:
					return BeerStyle.Gose;
				case BeerService.Style.IPA:
					return BeerStyle.IndianPaleAle;
				case BeerService.Style.Kolsch:
					return BeerStyle.Kolsch;
				case BeerService.Style.Lager:
					return BeerStyle.Lager;
				case BeerService.Style.Lambic:
					return BeerStyle.Lambic;
				case BeerService.Style.PaleAle:
					return BeerStyle.PaleAle;
				case BeerService.Style.Pilsner:
					return BeerStyle.Pilsner;
				case BeerService.Style.Porter:
					return BeerStyle.Porter;
				case BeerService.Style.Saison:
					return BeerStyle.Saison;
				case BeerService.Style.ScotchAle:
					return BeerStyle.ScotchAle;
				case BeerService.Style.Stout:
					return BeerStyle.Stout;
				case BeerService.Style.Tripel:
					return BeerStyle.Tripel;
				case BeerService.Style.Wheat:
					return BeerStyle.Wheat;
				default:
					return BeerStyle.Other;
			}
		}
	}
}
