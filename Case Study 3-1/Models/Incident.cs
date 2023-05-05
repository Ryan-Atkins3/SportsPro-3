using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Case_Study_3_1.Models
{
    public class Incident
    {
        public int IncidentId { get; set; }

        public int? CustomerId { get; set; }

        [ValidateNever]
        public Customer Customer { get; set; } = null!;

        public int? ProductId { get; set; }

        [ValidateNever]
        public Product Product { get; set; } = null!;

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int? TechnicianId { get; set; }

        [ValidateNever]
        public Technician Technician { get;set; } = null!;

        public DateTime DateOpened { get; set; } = DateTime.Today;

        public DateTime? DateClosed { get; set; } = null;
    }
}
