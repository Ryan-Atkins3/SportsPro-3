using CaseStudy31.Migrations;
using System.ComponentModel.DataAnnotations;

namespace Case_Study_3_1.Models
{
	public class Product
	{
		public Product() => Customers = new HashSet<Customer>();

		public int ProductId { get; set; }

		[Required(ErrorMessage = "You must enter a product code")]
		public string ProductCode { get; set; } = string.Empty;

		[Required(ErrorMessage = "The product  must have a name!")]
		public string ProductName { get; set; } = string.Empty;

		[Required(ErrorMessage = "You must enter a price!"), Range(0, double.MaxValue, ErrorMessage = "Price must be above 0!")]
		public double ProductPrice { get; set; }

		[DataType(DataType.DateTime, ErrorMessage = "Release date must be date.")]
		public DateTime ProductReleaseDate { get; set; } = DateTime.Now;

		public int CustomerId { get; set; }

		public ICollection<Customer> Customers { get; set;}
	}
}
