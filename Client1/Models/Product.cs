namespace Client1.Models
{
	public class Product
	{
		public string Name { get; set; }
		public int Price { get; set; }
		public int Stock { get; set; }

		public Product(string name, int price, int stock)
		{
			Name = name;
			Price = price;
			Stock = stock;
		}
	}
}
