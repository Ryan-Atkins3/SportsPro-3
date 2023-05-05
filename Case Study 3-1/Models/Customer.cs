using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Quarterly_Sales.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace Case_Study_3_1.Models
{
    public class Customer
    {
        public Customer() => Products = new HashSet<Product>(); 

        public int CustomerId { get; set; }

        [Required(ErrorMessage = "You must enter a first name")]
        [StringLength(51)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must enter a last name")]
        [StringLength(51)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must enter an address")]
        [StringLength(51)]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must enter a city")]
        [StringLength(51)]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must enter a state")]
        [StringLength(51)]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "you must enter a postal code")]
        [StringLength(21)]
        public string PostalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must enter a country")]
        [GreaterThan(0, ErrorMessage = "Please Select a country")]
        public int? CountryId { get; set; }

        [ValidateNever]
        public Country Country { get; set; } = null!;

        [Required(ErrorMessage = "You must enter an email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must enter a Phone Number")]
        [StringLength(21)]
        [RegularExpression("^\\(\\d{3}\\)\\s\\d{3}-\\d{4}", ErrorMessage = "Phone number must match (999) 999-9999 format.")]
        public string Phone { get; set; } = string.Empty;

        public int ProductId { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
