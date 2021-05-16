using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yellow.Models
{
	public class IndexViewModel
	{
		public IEnumerable<Product> AppleProducts { get; set; }
		public IEnumerable<Product> NewProducts { get; set; }
	}
}
