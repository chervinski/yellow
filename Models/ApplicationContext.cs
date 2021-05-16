using Microsoft.EntityFrameworkCore;

namespace Yellow.Models
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Category>().HasData(new Category() { Id = 1, Name = "phone" });
			modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer[] {
				new Manufacturer() { Id = 1, Name = "Apple" },
				new Manufacturer() { Id = 2, Name = "Samsung" },
				new Manufacturer() { Id = 3, Name = "Xiaomi" },
				new Manufacturer() { Id = 4, Name = "Huawei" }
			});

			Product[] products = new Product[40];
			for (int i = 0; i < products.Length; ++i)
			{
				products[i] = new Product { Id = i + 1, Name = "Apple iPhone 12 64GB (Black)", Price = 23799, ImageURL = "images/items/apple_iphone_12_64gb_black_1.jpg", CategoryId = 1, ManufacturerId = 1 };
				products[++i] = new Product { Id = i + 1, Name = "Samsung A715F Galaxy A71 6/128GB Blue Dual (UA UCRF)", Price = 10799, ImageURL = "images/items/file_1493_7.jpg", CategoryId = 1, ManufacturerId = 2 };
				products[++i] = new Product { Id = i + 1, Name = "Xiaomi Redmi 9 4/64GB (Grey) (NFC)", Price = 3999, ImageURL = "images/items/xiaomi-redmi-9-3-32gb-carbon-grey-eu_1__1.jpg", CategoryId = 1, ManufacturerId = 3 };
				products[++i] = new Product { Id = i + 1, Name = "Huawei P40 Pro 8/256GB (Blush Gold) (Global)", Price = 21299, ImageURL = "images/items/huawei-p40-pro-8256gb-gold.jpg", CategoryId = 1, ManufacturerId = 4 };
			}
			modelBuilder.Entity<Product>().HasData(products);
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Manufacturer> Manufacturers { get; set; }
	}
}
