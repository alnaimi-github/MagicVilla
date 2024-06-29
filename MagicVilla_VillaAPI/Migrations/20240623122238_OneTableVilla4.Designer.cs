﻿// <auto-generated />
using System;
using MagicVilla_VillaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240623122238_OneTableVilla4")]
    partial class OneTableVilla4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicVilla_VillaAPI.Models.LocalUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LocalUsers");
                });

            modelBuilder.Entity("MagicVilla_VillaAPI.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "Pool, Wi-Fi, BBQ",
                            CreatedDate = new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4648),
                            Details = "Beautiful villa with sea view.",
                            ImageUrl = "https://example.com/villa1.jpg",
                            Name = "Villa Sunshine",
                            Occupancy = 8,
                            Rate = 350.0,
                            Sqft = 2500,
                            UpdatedDate = new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4662)
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "Fireplace, Hot Tub",
                            CreatedDate = new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4667),
                            Details = "Cozy retreat in the mountains.",
                            ImageUrl = "https://example.com/villa2.jpg",
                            Name = "Mountain Retreat",
                            Occupancy = 6,
                            Rate = 200.0,
                            Sqft = 1500,
                            UpdatedDate = new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4668)
                        },
                        new
                        {
                            Id = 3,
                            Amenity = "Gym, Wi-Fi",
                            CreatedDate = new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4672),
                            Details = "Modern villa in the city center.",
                            ImageUrl = "https://example.com/villa3.jpg",
                            Name = "Urban Oasis",
                            Occupancy = 4,
                            Rate = 300.0,
                            Sqft = 1800,
                            UpdatedDate = new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4672)
                        },
                        new
                        {
                            Id = 4,
                            Amenity = "Pool, Private Beach",
                            CreatedDate = new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4675),
                            Details = "Luxury villa right on the beach.",
                            ImageUrl = "https://example.com/villa4.jpg",
                            Name = "Beachfront Paradise",
                            Occupancy = 10,
                            Rate = 500.0,
                            Sqft = 3000,
                            UpdatedDate = new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4676)
                        },
                        new
                        {
                            Id = 5,
                            Amenity = "Garden, Wi-Fi",
                            CreatedDate = new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4679),
                            Details = "Charming villa in the countryside.",
                            ImageUrl = "https://example.com/villa5.jpg",
                            Name = "Countryside Escape",
                            Occupancy = 5,
                            Rate = 250.0,
                            Sqft = 2200,
                            UpdatedDate = new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4680)
                        },
                        new
                        {
                            Id = 6,
                            Amenity = "Pool, Outdoor Shower",
                            CreatedDate = new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4682),
                            Details = "Quiet villa in the desert.",
                            ImageUrl = "https://example.com/villa6.jpg",
                            Name = "Desert Hideaway",
                            Occupancy = 4,
                            Rate = 280.0,
                            Sqft = 1600,
                            UpdatedDate = new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4683)
                        },
                        new
                        {
                            Id = 7,
                            Amenity = "Canoe, Fireplace",
                            CreatedDate = new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4686),
                            Details = "Relaxing villa by the lake.",
                            ImageUrl = "https://example.com/villa7.jpg",
                            Name = "Lakeside Cottage",
                            Occupancy = 6,
                            Rate = 220.0,
                            Sqft = 2000,
                            UpdatedDate = new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4687)
                        },
                        new
                        {
                            Id = 8,
                            Amenity = "Pool, Hammocks",
                            CreatedDate = new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4690),
                            Details = "Exotic villa in a tropical setting.",
                            ImageUrl = "https://example.com/villa8.jpg",
                            Name = "Tropical Getaway",
                            Occupancy = 8,
                            Rate = 400.0,
                            Sqft = 2700,
                            UpdatedDate = new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4691)
                        },
                        new
                        {
                            Id = 9,
                            Amenity = "Ski Storage, Hot Tub",
                            CreatedDate = new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4694),
                            Details = "Comfortable villa near the ski slopes.",
                            ImageUrl = "https://example.com/villa9.jpg",
                            Name = "Ski Chalet",
                            Occupancy = 5,
                            Rate = 310.0,
                            Sqft = 1400,
                            UpdatedDate = new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4694)
                        },
                        new
                        {
                            Id = 10,
                            Amenity = "Hiking Trails, Wi-Fi",
                            CreatedDate = new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4697),
                            Details = "Peaceful villa in the forest.",
                            ImageUrl = "https://example.com/villa10.jpg",
                            Name = "Forest Retreat",
                            Occupancy = 6,
                            Rate = 270.0,
                            Sqft = 1900,
                            UpdatedDate = new DateTime(2024, 6, 24, 1, 22, 34, 852, DateTimeKind.Local).AddTicks(4698)
                        });
                });

            modelBuilder.Entity("MagicVilla_VillaAPI.Models.VillaNumber", b =>
                {
                    b.Property<int>("VillaNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SpecialDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VillaId")
                        .HasColumnType("int");

                    b.HasKey("VillaNo");

                    b.HasIndex("VillaId");

                    b.ToTable("VillaNumbers");
                });

            modelBuilder.Entity("MagicVilla_VillaAPI.Models.VillaNumber", b =>
                {
                    b.HasOne("MagicVilla_VillaAPI.Models.Villa", "Villa")
                        .WithMany()
                        .HasForeignKey("VillaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Villa");
                });
#pragma warning restore 612, 618
        }
    }
}
