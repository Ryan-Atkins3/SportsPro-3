namespace Case_Study_3_1.Models
{
	public class TechIncidentViewModel
	{
		public Technician Technician { get; set; } = null!;

		public Incident Incident { get; set; } = null!;

		public IEnumerable<Incident> Incidents { get; set; } = null!;
	}
}
