using Api1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{

		private static List<Product> productList = new List<Product>() {
			new Product("kalem",15,30),
			new Product("defter",35,40),
			new Product("silgi",10,20)
		};

		[Authorize(Policy = "readProduct")]
		[HttpGet]
		public IActionResult GetProducts()
		{
			return Ok(productList);
		}

		[Authorize(Policy = "createOrUpdateProduct")]
		[HttpPut]
		public IActionResult UpdateProduct(Product product) {
			
			Product? p = productList.FirstOrDefault(x => x.Id == product.Id);
			
			if(p == null) return NotFound();
			
			p.Name = product.Name;
			p.Price = product.Price;
			p.Stock = product.Stock;
			return Ok(p);
		}
	}
}
