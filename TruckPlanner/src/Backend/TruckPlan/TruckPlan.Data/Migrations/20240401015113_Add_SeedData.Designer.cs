﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TruckPlan.Data;

#nullable disable

namespace TruckPlan.Data.Migrations
{
    [DbContext(typeof(TruckPlanContext))]
    [Migration("20240401015113_Add_SeedData")]
    partial class Add_SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TruckPlan.Data.Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DrivingLicenseNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Drivers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1974, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DrivingLicenseNumber = 12345,
                            Name = "Michael Lund"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1990, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DrivingLicenseNumber = 6789,
                            Name = "Jeppe Wilson"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1984, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DrivingLicenseNumber = 76543,
                            Name = "Sophia Garcia"
                        });
                });

            modelBuilder.Entity("TruckPlan.Data.Models.TripPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TripEndDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("TripEndLatitude")
                        .HasColumnType("float");

                    b.Property<double>("TripEndLongitude")
                        .HasColumnType("float");

                    b.Property<DateTime>("TripStartDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("TripStartLatitude")
                        .HasColumnType("float");

                    b.Property<double>("TripStartLongitude")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.ToTable("TripPlans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DriverId = 1,
                            TripEndDate = new DateTime(2018, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TripEndLatitude = 53.551085999999998,
                            TripEndLongitude = 9.9936819999999997,
                            TripStartDate = new DateTime(2018, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TripStartLatitude = 52.520007999999997,
                            TripStartLongitude = 13.404954
                        },
                        new
                        {
                            Id = 2,
                            DriverId = 2,
                            TripEndDate = new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TripEndLatitude = 55.396228999999998,
                            TripEndLongitude = 10.390599999999999,
                            TripStartDate = new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TripStartLatitude = 55.676098000000003,
                            TripStartLongitude = 12.568337
                        },
                        new
                        {
                            Id = 3,
                            DriverId = 3,
                            TripEndDate = new DateTime(2021, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TripEndLatitude = 55.605293099999997,
                            TripEndLongitude = 13.0001566,
                            TripStartDate = new DateTime(2021, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TripStartLatitude = 59.325117200000001,
                            TripStartLongitude = 18.0710935
                        },
                        new
                        {
                            Id = 4,
                            DriverId = 3,
                            TripEndDate = new DateTime(2018, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TripEndLatitude = 48.778448500000003,
                            TripEndLongitude = 9.1800131999999994,
                            TripStartDate = new DateTime(2018, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TripStartLatitude = 50.110644399999998,
                            TripStartLongitude = 8.6820917000000009
                        },
                        new
                        {
                            Id = 5,
                            DriverId = 2,
                            TripEndDate = new DateTime(2019, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TripEndLatitude = 52.517036500000003,
                            TripEndLongitude = 13.3888599,
                            TripStartDate = new DateTime(2019, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TripStartLatitude = 50.938361,
                            TripStartLongitude = 6.9599739999999999
                        });
                });

            modelBuilder.Entity("TruckPlan.Data.Models.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DriverId")
                        .IsUnique();

                    b.ToTable("Trucks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DriverId = 1,
                            ModelName = "Volvo",
                            Vin = "ABC12345"
                        },
                        new
                        {
                            Id = 2,
                            DriverId = 2,
                            ModelName = "Tesla",
                            Vin = "MMO12345"
                        },
                        new
                        {
                            Id = 3,
                            DriverId = 3,
                            ModelName = "Scania",
                            Vin = "QWER12345"
                        });
                });

            modelBuilder.Entity("TruckPlan.Data.Models.TripPlan", b =>
                {
                    b.HasOne("TruckPlan.Data.Models.Driver", "Driver")
                        .WithMany("TripPlans")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("TruckPlan.Data.Models.Truck", b =>
                {
                    b.HasOne("TruckPlan.Data.Models.Driver", "Driver")
                        .WithOne("Truck")
                        .HasForeignKey("TruckPlan.Data.Models.Truck", "DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("TruckPlan.Data.Models.Driver", b =>
                {
                    b.Navigation("TripPlans");

                    b.Navigation("Truck")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
