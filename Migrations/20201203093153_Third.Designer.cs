﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TKXDPM_API;

namespace TKXDPM_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201203093153_Third")]
    partial class Third
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TKXDPM_API.Model.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("AddressName")
                        .HasColumnType("varchar(255)");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("TKXDPM_API.Model.Bike", b =>
                {
                    b.Property<int>("BikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("BatterCapacity")
                        .HasColumnType("integer");

                    b.Property<string>("BikeName")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Deposit")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("HourlyRent")
                        .HasColumnType("integer");

                    b.Property<string>("LicensePlates")
                        .HasColumnType("varchar(255)");

                    b.Property<float>("PowerDrain")
                        .HasColumnType("real");

                    b.Property<int>("StartingRent")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("BikeId");

                    b.ToTable("Bikes");
                });

            modelBuilder.Entity("TKXDPM_API.Model.BikeInStation", b =>
                {
                    b.Property<int>("BikeId")
                        .HasColumnType("integer");

                    b.Property<int>("StationId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTimeIn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateTimeOut")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("BikeId", "StationId");

                    b.HasIndex("StationId");

                    b.ToTable("BikeInStation");
                });

            modelBuilder.Entity("TKXDPM_API.Model.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("Cvv")
                        .HasColumnType("integer");

                    b.Property<string>("ExpirationDate")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("RenterId")
                        .HasColumnType("integer");

                    b.HasKey("CardId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("TKXDPM_API.Model.Rental", b =>
                {
                    b.Property<int>("RentalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("BikeId")
                        .HasColumnType("integer");

                    b.Property<int>("CardId")
                        .HasColumnType("integer");

                    b.Property<string>("RateContent")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("RateNumber")
                        .HasColumnType("integer");

                    b.Property<int>("RenterId")
                        .HasColumnType("integer");

                    b.Property<string>("RenterId1")
                        .HasColumnType("varchar(255)");

                    b.HasKey("RentalId");

                    b.HasIndex("BikeId");

                    b.HasIndex("CardId");

                    b.HasIndex("RenterId1");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("TKXDPM_API.Model.Renter", b =>
                {
                    b.Property<string>("RenterId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("RenterId");

                    b.ToTable("Renters");
                });

            modelBuilder.Entity("TKXDPM_API.Model.Station", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<float>("Area")
                        .HasColumnType("real");

                    b.Property<string>("ContactName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(255)");

                    b.HasKey("StationId");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("TKXDPM_API.Model.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("ActualEndDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("ActualStartDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("BookedEndDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("BookedStartDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("RentalId")
                        .HasColumnType("integer");

                    b.HasKey("TransactionId");

                    b.HasIndex("RentalId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("TKXDPM_API.Model.BikeInStation", b =>
                {
                    b.HasOne("TKXDPM_API.Model.Bike", "Bike")
                        .WithMany()
                        .HasForeignKey("BikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TKXDPM_API.Model.Station", "Station")
                        .WithMany()
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bike");

                    b.Navigation("Station");
                });

            modelBuilder.Entity("TKXDPM_API.Model.Rental", b =>
                {
                    b.HasOne("TKXDPM_API.Model.Bike", "Bike")
                        .WithMany()
                        .HasForeignKey("BikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TKXDPM_API.Model.Card", "Card")
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TKXDPM_API.Model.Renter", "Renter")
                        .WithMany()
                        .HasForeignKey("RenterId1");

                    b.Navigation("Bike");

                    b.Navigation("Card");

                    b.Navigation("Renter");
                });

            modelBuilder.Entity("TKXDPM_API.Model.Transaction", b =>
                {
                    b.HasOne("TKXDPM_API.Model.Rental", "Rental")
                        .WithMany()
                        .HasForeignKey("RentalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rental");
                });
#pragma warning restore 612, 618
        }
    }
}
