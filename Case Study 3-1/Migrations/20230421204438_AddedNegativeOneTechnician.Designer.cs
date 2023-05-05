﻿// <auto-generated />
using System;
using Case_Study_3_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CaseStudy31.Migrations
{
    [DbContext(typeof(SportsProContext))]
    [Migration("20230421204438_AddedNegativeOneTechnician")]
    partial class AddedNegativeOneTechnician
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Case_Study_3_1.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"));

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            CountryName = "United States of America"
                        },
                        new
                        {
                            CountryId = 2,
                            CountryName = "Canada"
                        },
                        new
                        {
                            CountryId = 3,
                            CountryName = "Cuba"
                        },
                        new
                        {
                            CountryId = 4,
                            CountryName = "Swizterland"
                        },
                        new
                        {
                            CountryId = 5,
                            CountryName = "United Kingdom"
                        });
                });

            modelBuilder.Entity("Case_Study_3_1.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.Property<int?>("CountryId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(51)
                        .HasColumnType("nvarchar(51)");

                    b.HasKey("CustomerId");

                    b.HasIndex("CountryId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "3583 Sunrise Dr",
                            City = "Imperial",
                            CountryId = 1,
                            Email = "ratkins@example.com",
                            FirstName = "Ryan",
                            LastName = "Atkins",
                            Phone = "314-717-4548",
                            PostalCode = "63052",
                            State = "Missouri"
                        });
                });

            modelBuilder.Entity("Case_Study_3_1.Models.Incident", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IncidentId"));

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateClosed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOpened")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("TechnicianId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IncidentId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("Incidents");

                    b.HasData(
                        new
                        {
                            IncidentId = 1,
                            CustomerId = 7,
                            DateOpened = new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Program fails with error code 510, unable to open database",
                            ProductId = 2,
                            Title = "Error Launching Program"
                        });
                });

            modelBuilder.Entity("Case_Study_3_1.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("ProductReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ProductCode = "TRNY10",
                            ProductName = "Tournement Master 1.0",
                            ProductPrice = 4.9900000000000002,
                            ProductReleaseDate = new DateTime(2018, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductId = 2,
                            ProductCode = "LEAG10",
                            ProductName = "League  Scheduler 1.0",
                            ProductPrice = 4.9900000000000002,
                            ProductReleaseDate = new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductId = 3,
                            ProductCode = "LEAGd10",
                            ProductName = "League  Scheduler Deluxe 1.0",
                            ProductPrice = 7.9900000000000002,
                            ProductReleaseDate = new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductId = 4,
                            ProductCode = "DRAFT10",
                            ProductName = "Draft Manager 1.0",
                            ProductPrice = 4.9900000000000002,
                            ProductReleaseDate = new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductId = 5,
                            ProductCode = "TEAM10",
                            ProductName = "Team Manager 1.0",
                            ProductPrice = 4.9900000000000002,
                            ProductReleaseDate = new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductId = 6,
                            ProductCode = "LEAG10",
                            ProductName = "League  Scheduler 1.0",
                            ProductPrice = 4.9900000000000002,
                            ProductReleaseDate = new DateTime(2018, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductId = 7,
                            ProductCode = "TRNY20",
                            ProductName = "Tournement Master 2.0",
                            ProductPrice = 5.9900000000000002,
                            ProductReleaseDate = new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductId = 8,
                            ProductCode = "DRAFT20",
                            ProductName = "Draft Manager 2.0",
                            ProductPrice = 5.9900000000000002,
                            ProductReleaseDate = new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Case_Study_3_1.Models.Technician", b =>
                {
                    b.Property<int>("TechnicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TechnicianId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechnicianName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TechnicianId");

                    b.ToTable("Technicians");

                    b.HasData(
                        new
                        {
                            TechnicianId = -1,
                            Email = "",
                            PhoneNumber = "",
                            TechnicianName = ""
                        },
                        new
                        {
                            TechnicianId = 1,
                            Email = "alison@sportsprosoftware.com",
                            PhoneNumber = "800-555-0443",
                            TechnicianName = "Alison Diaz"
                        },
                        new
                        {
                            TechnicianId = 2,
                            Email = "awilson@sportsprosoftware.com",
                            PhoneNumber = "800-555-0449",
                            TechnicianName = "Andrew Wilson"
                        },
                        new
                        {
                            TechnicianId = 3,
                            Email = "gfiori@sportsprosoftware.com",
                            PhoneNumber = "800-555-0459",
                            TechnicianName = "Gina Fiori"
                        },
                        new
                        {
                            TechnicianId = 4,
                            Email = "gunter@sportsprosoftware.com",
                            PhoneNumber = "800-555-0400",
                            TechnicianName = "Gunter Wendt"
                        },
                        new
                        {
                            TechnicianId = 5,
                            Email = "jason@sportsprosoftware.com",
                            PhoneNumber = "800-555-0444",
                            TechnicianName = "Jason Lee"
                        });
                });

            modelBuilder.Entity("Case_Study_3_1.Models.Customer", b =>
                {
                    b.HasOne("Case_Study_3_1.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Case_Study_3_1.Models.Incident", b =>
                {
                    b.HasOne("Case_Study_3_1.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("Case_Study_3_1.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("Case_Study_3_1.Models.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId");

                    b.Navigation("Customer");

                    b.Navigation("Product");

                    b.Navigation("Technician");
                });
#pragma warning restore 612, 618
        }
    }
}
