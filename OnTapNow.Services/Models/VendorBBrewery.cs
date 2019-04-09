namespace OnTapNow.Services.Models
{

	public class VendorBBrewery
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public object WebAddress { get; set; }
		public object Phone { get; set; }
		public Address Address { get; set; }
	}

	public class Address
	{
		public string Street1 { get; set; }
		public string Street2 { get; set; }
		public string City { get; set; }
		public string StateCode { get; set; }
		public string ZipCode { get; set; }
	}
}
