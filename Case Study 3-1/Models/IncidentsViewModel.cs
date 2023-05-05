using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Case_Study_3_1.Models
{
    public class IncidentsViewModel
    {
        [ValidateNever]
        public List<Incident> Incidents { get; set; } = null!;

		[ValidateNever]
		public List<Customer> Customers { get; set; } = null!;

		[ValidateNever]
		public List<Product> Products { get; set; } = null!;

		[ValidateNever]
		public List<Technician> Technicians { get; set; } = null!;

        public Incident incident { get; set; } = null!;

        public string Displayed = string.Empty;

        public string Operation = string.Empty;
    }
}
