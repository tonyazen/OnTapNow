using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using log4net;
using Newtonsoft.Json;
using OnTapNow.Business;
using OnTapNow.Services.Mapper;

namespace OnTapNow.Services
{
	public class VendorBBreweryService : IBreweryServices
	{
		private readonly HttpClient _client = new HttpClient();
		private readonly VendorBBreweryMapper _mapper = new VendorBBreweryMapper();
		private static readonly ILog Logger = LogManager.GetLogger(typeof(VendorBBreweryService));
		private const string BaseAddress = "http://localhost:56770/api/";

		public async Task<BreweriesResponse> GetBreweries()
		{
			var path = "brewery";
			var breweriesResponse = new BreweriesResponse();

			using (_client)
			{
				_client.BaseAddress = new Uri(BaseAddress);
				_client.DefaultRequestHeaders.Accept.Clear();
				_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				try
				{
					var response = await _client.GetAsync(path);

					if (response.IsSuccessStatusCode)
					{
						var breweries = await response.Content.ReadAsStringAsync();
						var serviceBreweries = JsonConvert.DeserializeObject<Models.VendorBBrewery[]>(breweries);
						breweriesResponse.Success = true;
						breweriesResponse.Breweries = _mapper.MapBreweries(serviceBreweries);
						return breweriesResponse;
					}
				}
				catch (Exception ex)
				{
					Logger.ErrorFormat($"Get Breweries failed. Path: {path}. Exception: {ex}.");
				}

				breweriesResponse.Success = false;
				breweriesResponse.Message = "We're sorry, there was a problem getting breweries. :(";
				breweriesResponse.Breweries = new List<Brewery>();
				return breweriesResponse;
			}
		}

		public async Task<BreweryResponse> GetBrewery(string id)
		{
			var path = $"brewery/{id}";
			var breweryResponse = new BreweryResponse();

			using (_client)
			{
				_client.BaseAddress = new Uri(BaseAddress);
				_client.DefaultRequestHeaders.Accept.Clear();
				_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				try
				{
					var response = await _client.GetAsync(path);

					if (response.IsSuccessStatusCode)
					{
						var brewery = await response.Content.ReadAsStringAsync();
						var serviceBrewery = JsonConvert.DeserializeObject<Models.VendorBBrewery>(brewery);
						breweryResponse.Success = true;
						breweryResponse.Brewery = _mapper.MapBrewery(serviceBrewery);
						return breweryResponse;
					}
				}
				catch (Exception ex)
				{
					Logger.ErrorFormat($"Get Brewery failed. Path: {path}. Exception: {ex}.");
				}

				breweryResponse.Success = false;
				breweryResponse.Message = "We're sorry, there was a problem getting that brewery. :(";
				breweryResponse.Brewery = new Brewery();
				return breweryResponse;
			}
		}
	}
}
