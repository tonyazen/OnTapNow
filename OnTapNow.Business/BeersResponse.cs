using System.Collections.Generic;

namespace OnTapNow.Business
{
	public class BeersResponse : BaseResponse
	{
		public List<Beer> Beers { get; set; }
	}
}
