using System;

namespace OnTapNow.Business
{
	[Serializable]
	public class Brewery
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public Address Address { get; set; }
	}

	[Serializable]
	public class Address
	{
		public string Street1 { get; set; }
		public string Street2 { get; set; }
		public string City { get; set; }
		public string StateCode { get; set; }
		public string ZipCode { get; set; }
	}
}
