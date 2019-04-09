using System;

namespace OnTapNow.Business
{
	[Serializable]
	public class Beer
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Abv { get; set; }
		public BeerStyle Style { get; set; }
		public string Description { get; set; }
		public bool IsOnTap { get; set; }
		public Brewery Brewery { get; set; }
	}

	[Serializable]
	public enum BeerStyle
	{
		Ale,
		Lager,
		Stout,
		IndianPaleAle,
		PaleAle,
		Pilsner,
		Wheat,
		BrownAle,
		Bitter,
		Boch,
		BarleyWine,
		Porter,
		Saison,
		PaleLager,
		Lambic,
		Kolsch,
		OldAle,
		MidAle,
		Dunkel,
		Marzen,
		CreamAle,
		Tripel,
		Dubbel,
		Gose,
		Red,
		AmericanPaleAle,
		ScotchAle,
		Rye,
		Unkown,
		Other
	}
}
