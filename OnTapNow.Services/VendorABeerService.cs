using System;
using System.Collections.Generic;
using log4net;
using OnTapNow.Business;
using OnTapNow.Services.BeerService;
using OnTapNow.Services.Mapper;
using BaseResponse = OnTapNow.Business.BaseResponse;
using Beer = OnTapNow.Business.Beer;

namespace OnTapNow.Services
{
	public class VendorABeerService : IBeerServices
	{
		private static readonly ILog Logger = LogManager.GetLogger(typeof(VendorABeerService));
		private readonly VendorABeerMapper _mapper = new VendorABeerMapper();

		public BeersResponse GetBeers()
		{
			var client = new BeerWithSoapServiceClient();

			var getAllBeersRequest = new GetAllBeersRequest
			{
				BaseRequest = new BaseRequest
				{
					APIKey = "ILoveBeer",
					ClientCode = "TonyaZen",
					RequestId = Guid.NewGuid().ToString(),
					Version = "V1"
				}
			};

			try
			{
				var response = client.GetAllBeers(getAllBeersRequest);

				if (response.BaseResponse.ResponseStatus == ResponseStatus.Success)
				{
					client.Close();

					return new BeersResponse
					{
						Success = true,
						Beers = _mapper.MapBeers(response.Beers)
					};
				}

				Logger.ErrorFormat("Get Beers failed for " +
				                   $"client: {getAllBeersRequest.BaseRequest.ClientCode}. " +
				                   $"RequestID: {getAllBeersRequest.BaseRequest.RequestId}. " +
				                   $"Error from Service: {response.BaseResponse.TechnicalErrorMessage}.");

				return new BeersResponse
				{
					Success = false,
					Message = response.BaseResponse.DisplayErrorMessage,
					Beers = new List<Beer>()
				};
			}
			catch (Exception ex)
			{
				Logger.ErrorFormat("Get Beers failed for " +
				                   $"client: {getAllBeersRequest.BaseRequest.ClientCode}. " +
				                   $"RequestID: {getAllBeersRequest.BaseRequest.RequestId}. " +
				                   $"Exception: {ex}.");
				client.Abort();

				return new BeersResponse
				{
					Success = false,
					Message = "We're sorry, there was a problem getting your beers. :(",
					Beers = new List<Beer>()
				};
			}
		}

		public BeerResponse GetBeer(string id)
		{
			var client = new BeerWithSoapServiceClient();

			var getBeerRequest = new GetBeerRequest
			{
				BaseRequest = new BaseRequest
				{
					APIKey = "ILoveBeer",
					ClientCode = "TonyaZen",
					RequestId = Guid.NewGuid().ToString(),
					Version = "V1"
				},

				Id = Convert.ToInt32(id)
			};

			try
			{
				var response = client.GetBeer(getBeerRequest);

				if (response.BaseResponse.ResponseStatus == ResponseStatus.Success)
				{
					client.Close();

					return new BeerResponse
					{
						Success = true,
						Beer = _mapper.MapBeer(response.Beer)
					};
				}

				Logger.ErrorFormat("Get Beer failed for " +
				                   $"client: {getBeerRequest.BaseRequest.ClientCode}. " +
				                   $"RequestID: {getBeerRequest.BaseRequest.RequestId}. " +
				                   $"BeerId: {getBeerRequest.Id}. " +
				                   $"Error from Service: {response.BaseResponse.TechnicalErrorMessage}.");

				return new BeerResponse
				{
					Success = false,
					Message = response.BaseResponse.DisplayErrorMessage,
					Beer = new Beer()
				};
			}
			catch (Exception ex)
			{
				Logger.ErrorFormat("Get Beer failed for " +
				                   $"client: {getBeerRequest.BaseRequest.ClientCode}. " +
				                   $"RequestID: {getBeerRequest.BaseRequest.RequestId}. " +
				                   $"BeerId: {getBeerRequest.Id}. " +
				                   $"Exception: {ex}.");
				client.Abort();

				return new BeerResponse
				{
					Success = false,
					Message = "We're sorry, there was a problem getting your beer. :(",
					Beer = new Beer()
				};
			}
		}

		public BeerResponse AddBeer(Beer beer)
		{
			throw new NotImplementedException();
		}

		public BeerResponse UpdateBeer(Beer beer)
		{
			throw new NotImplementedException();
		}

		public BaseResponse DeleteBeer(string id)
		{
			throw new NotImplementedException();
		}
	}
}
