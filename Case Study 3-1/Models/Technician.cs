using System.ComponentModel.DataAnnotations;

namespace Case_Study_3_1.Models
{
	public class Technician
	{

		public int TechnicianId { get; set; }

		[Required(ErrorMessage = "You must enter a Name!")]
		public string TechnicianName { get; set; } = string.Empty;

		[Required(ErrorMessage = "You must enter an email!")]
		[EmailAddress(ErrorMessage = "The email must be a valid email address!")]
		public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "There must be a phone number!")]
		[Phone(ErrorMessage = "The phone number must be a valid phone number!")]
		public string PhoneNumber { get; set; } = string.Empty;

	}
}
