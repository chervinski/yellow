using System.Collections.Generic;

namespace Yellow.Models
{
	public class CategoryViewModel
	{
		public string CategoryName { get; set; }
		public string ManufacturerName { get; set; }
		public IEnumerable<Product> Products { get; set; }
		public IEnumerable<Manufacturer> Manufacturers { get; set; }
	}
}
