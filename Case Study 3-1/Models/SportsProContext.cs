using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Case_Study_3_1.Models;

namespace Case_Study_3_1.Models
{
	public class SportsProContext : IdentityDbContext<User>
	{
		public SportsProContext(DbContextOptions<SportsProContext> options)
			: base(options)
		{ }

		public DbSet<Product> Products { get; set; } = null!;
		public DbSet<Technician> Technicians { get; set; } = null!;
		public DbSet<Country> Countries { get; set; } = null!;
		public DbSet<Customer> Customers { get; set; } = null!;
		public DbSet<Incident> Incidents { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Incident>().HasData(
                new Incident { IncidentId = 1, CustomerId = 7, ProductId = 2, Title = "Error Launching Program", Description = "Program fails with error code 510, unable to open database" }
                );

            modelBuilder.Entity<Customer>().HasData(
				new Customer { CustomerId = 1, FirstName = "Ryan", LastName = "Atkins", Address = "3583 Sunrise Dr", City = "Imperial", State = "Missouri", PostalCode = "63052", CountryId = 1, Email = "ratkins@example.com", Phone = "314-717-4548" }
				);

			modelBuilder.Entity<Country>().HasData(
				new Country { CountryId = 1, CountryName = "United States of America"},
				new Country { CountryId = 2, CountryName = "Canada"},
				new Country { CountryId = 3, CountryName = "Cuba"},
				new Country { CountryId = 4, CountryName = "Swizterland"},
				new Country { CountryId = 5, CountryName = "United Kingdom"}
				);

			modelBuilder.Entity<Technician>().HasData(
                new Technician { TechnicianId = -1, TechnicianName = "", Email = "", PhoneNumber = "" },
                new Technician { TechnicianId = 1, TechnicianName = "Alison Diaz", Email = "alison@sportsprosoftware.com", PhoneNumber = "800-555-0443" },
				new Technician { TechnicianId = 2, TechnicianName = "Andrew Wilson", Email = "awilson@sportsprosoftware.com", PhoneNumber = "800-555-0449" },
				new Technician { TechnicianId = 3, TechnicianName = "Gina Fiori", Email = "gfiori@sportsprosoftware.com", PhoneNumber = "800-555-0459" },
				new Technician { TechnicianId = 4, TechnicianName = "Gunter Wendt", Email = "gunter@sportsprosoftware.com", PhoneNumber = "800-555-0400" },
				new Technician { TechnicianId = 5, TechnicianName = "Jason Lee", Email = "jason@sportsprosoftware.com", PhoneNumber = "800-555-0444" }
				);

			modelBuilder.Entity<Product>().HasData(
				new Product
				{
					ProductId = 1,
					ProductCode = "TRNY10",
					ProductName = "Tournement Master 1.0",
					ProductPrice = 4.99,
					ProductReleaseDate = DateTime.Parse("12/01/2018"),
				},
				new Product
				{
					ProductId = 2,
					ProductCode = "LEAG10",
					ProductName = "League  Scheduler 1.0",
					ProductPrice = 4.99,
					ProductReleaseDate = DateTime.Parse("05/01/2019"),
				},
				new Product
				{
					ProductId = 3,
					ProductCode = "LEAGd10",
					ProductName = "League  Scheduler Deluxe 1.0",
					ProductPrice = 7.99,
					ProductReleaseDate = DateTime.Parse("08/01/2019"),
				},
				new Product
				{
					ProductId = 4,
					ProductCode = "DRAFT10",
					ProductName = "Draft Manager 1.0",
					ProductPrice = 4.99,
					ProductReleaseDate = DateTime.Parse("02/01/2020"),
				},
				new Product
				{
					ProductId = 5,
					ProductCode = "TEAM10",
					ProductName = "Team Manager 1.0",
					ProductPrice = 4.99,
					ProductReleaseDate = DateTime.Parse("05/01/2018"),
				},
				new Product
				{
					ProductId = 6,
					ProductCode = "LEAG10",
					ProductName = "League  Scheduler 1.0",
					ProductPrice = 4.99,
					ProductReleaseDate = DateTime.Parse("05/01/2018"),
				},
				new Product
				{
					ProductId = 7,
					ProductCode = "TRNY20",
					ProductName = "Tournement Master 2.0",
					ProductPrice = 5.99,
					ProductReleaseDate = DateTime.Parse("02/15/2021"),
				},
				new Product
				{
					ProductId = 8,
					ProductCode = "DRAFT20",
					ProductName = "Draft Manager 2.0",
					ProductPrice = 5.99,
					ProductReleaseDate = DateTime.Parse("07/15/2022"),
				}


				);
		}
	}
}
