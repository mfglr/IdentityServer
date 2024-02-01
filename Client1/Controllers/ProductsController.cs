using Client1.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client1.Controllers
{
	public class ProductsController : Controller
	{
		private readonly IConfiguration _configuration;

		public ProductsController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task<IActionResult> Index()
		{
			HttpClient client = new HttpClient();
			var dicovery = await client.GetDiscoveryDocumentAsync("https://localhost:7127");
			if (dicovery.IsError)
			{

			}

			ClientCredentialsTokenRequest request = new ClientCredentialsTokenRequest();
			request.ClientId = _configuration["client:ClientId"];
			request.ClientSecret = _configuration["client:Secret"];
			request.Address = dicovery.TokenEndpoint;

			var token = await client.RequestClientCredentialsTokenAsync(request);
			
			if (token.IsError)
			{

			}

			client.SetBearerToken(token.AccessToken);


			var response = await client.GetAsync("https://localhost:7028/api/products/getproducts");
			
			if(!response.IsSuccessStatusCode)
			{

			}

			var content = await response.Content.ReadAsStringAsync();

			var products = JsonConvert.DeserializeObject<List<Product>>(content);

			return View(products);
		}
	}
}
