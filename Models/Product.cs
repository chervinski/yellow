namespace Yellow.Models
{
    public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public string ImageURL { get; set; }
		public int CategoryId { get; set; }
		public int ManufacturerId { get; set; }
		public virtual Category Category { get; set; }
		public virtual Manufacturer Manufacturer { get; set; }
	}
}
