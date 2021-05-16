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
			modelBuilder.Entity<Category>().HasData(new Manufacturer[] {
				new Manufacturer() { Id = 1, Name = "Apple" },
				new Manufacturer() { Id = 2, Name = "Samsung" },
				new Manufacturer() { Id = 3, Name = "Xiaomi" },
				new Manufacturer() { Id = 4, Name = "Huawei" }
			});
			modelBuilder.Entity<Product>().HasData( new Product[] {
				new Product { Id = 1, Name = "Apple iPhone 12 64GB (Black)", Price = 23799, ImageURL = "images/apple_iphone_12_64gb_black_1.jpg", CategoryId = 1, ManufacturerId = 1 },
				new Product { Id = 2, Name = "Samsung A715F Galaxy A71 6/128GB Blue Dual (UA UCRF)", Price = 10799, ImageURL = "images/file_1493_7.jpg", CategoryId = 1, ManufacturerId = 2 },
				new Product { Id = 3, Name = "Xiaomi Redmi 9 4/64GB (Grey) (NFC)", Price = 3999, ImageURL = "images/xiaomi-redmi-9-3-32gb-carbon-grey-eu_1__1.jpg", CategoryId = 1, ManufacturerId = 3 },
				new Product { Id = 4, Name = "Huawei P40 Pro 8/256GB (Blush Gold) (Global)", Price = 21299, ImageURL = "images/huawei-p40-pro-8256gb-gold.jpg", CategoryId = 1, ManufacturerId = 4 }
			});
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Manufacturer> Manufacturers { get; set; }
	}
}
