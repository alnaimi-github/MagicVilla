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
    [Migration("20240626131345_ImageFiled3")]
    partial class ImageFiled3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicVilla_VillaAPI.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

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

            modelBuilder.Entity("MagicVilla_VillaAPI.Models.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExpireAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<string>("JwtTokenId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshJwtToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RefreshTokens");
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

                    b.Property<string>("ImageLocalPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
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
                            CreatedDate = new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2326),
                            Details = "Beautiful villa with sea view.",
                            ImageLocalPath = "https://example.com/villa1.jpg",
                            ImageUrl = "",
                            Name = "Villa Sunshine",
                            Occupancy = 8,
                            Rate = 350.0,
                            Sqft = 2500,
                            UpdatedDate = new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2342)
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "Fireplace, Hot Tub",
                            CreatedDate = new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2351),
                            Details = "Cozy retreat in the mountains.",
                            ImageLocalPath = "https://example.com/villa2.jpg",
                            ImageUrl = "",
                            Name = "Mountain Retreat",
                            Occupancy = 6,
                            Rate = 200.0,
                            Sqft = 1500,
                            UpdatedDate = new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2352)
                        },
                        new
                        {
                            Id = 3,
                            Amenity = "Gym, Wi-Fi",
                            CreatedDate = new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2357),
                            Details = "Modern villa in the city center.",
                            ImageLocalPath = "https://example.com/villa3.jpg",
                            ImageUrl = "",
                            Name = "Urban Oasis",
                            Occupancy = 4,
                            Rate = 300.0,
                            Sqft = 1800,
                            UpdatedDate = new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2358)
                        },
                        new
                        {
                            Id = 4,
                            Amenity = "Pool, Private Beach",
                            CreatedDate = new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2361),
                            Details = "Luxury villa right on the beach.",
                            ImageLocalPath = "https://example.com/villa4.jpg",
                            ImageUrl = "",
                            Name = "Beachfront Paradise",
                            Occupancy = 10,
                            Rate = 500.0,
                            Sqft = 3000,
                            UpdatedDate = new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2362)
                        },
                        new
                        {
                            Id = 5,
                            Amenity = "Garden, Wi-Fi",
                            CreatedDate = new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2365),
                            Details = "Charming villa in the countryside.",
                            ImageLocalPath = "https://example.com/villa5.jpg",
                            ImageUrl = "",
                            Name = "Countryside Escape",
                            Occupancy = 5,
                            Rate = 250.0,
                            Sqft = 2200,
                            UpdatedDate = new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2367)
                        },
                        new
                        {
                            Id = 6,
                            Amenity = "Pool, Outdoor Shower",
                            CreatedDate = new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2370),
                            Details = "Quiet villa in the desert.",
                            ImageLocalPath = "https://example.com/villa6.jpg",
                            ImageUrl = "",
                            Name = "Desert Hideaway",
                            Occupancy = 4,
                            Rate = 280.0,
                            Sqft = 1600,
                            UpdatedDate = new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2371)
                        },
                        new
                        {
                            Id = 7,
                            Amenity = "Canoe, Fireplace",
                            CreatedDate = new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2374),
                            Details = "Relaxing villa by the lake.",
                            ImageLocalPath = "https://example.com/villa7.jpg",
                            ImageUrl = "",
                            Name = "Lakeside Cottage",
                            Occupancy = 6,
                            Rate = 220.0,
                            Sqft = 2000,
                            UpdatedDate = new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2376)
                        },
                        new
                        {
                            Id = 8,
                            Amenity = "Pool, Hammocks",
                            CreatedDate = new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2379),
                            Details = "Exotic villa in a tropical setting.",
                            ImageLocalPath = "https://example.com/villa8.jpg",
                            ImageUrl = "",
                            Name = "Tropical Getaway",
                            Occupancy = 8,
                            Rate = 400.0,
                            Sqft = 2700,
                            UpdatedDate = new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2380)
                        },
                        new
                        {
                            Id = 9,
                            Amenity = "Ski Storage, Hot Tub",
                            CreatedDate = new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2383),
                            Details = "Comfortable villa near the ski slopes.",
                            ImageLocalPath = "https://example.com/villa9.jpg",
                            ImageUrl = "",
                            Name = "Ski Chalet",
                            Occupancy = 5,
                            Rate = 310.0,
                            Sqft = 1400,
                            UpdatedDate = new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2385)
                        },
                        new
                        {
                            Id = 10,
                            Amenity = "Hiking Trails, Wi-Fi",
                            CreatedDate = new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2388),
                            Details = "Peaceful villa in the forest.",
                            ImageLocalPath = "https://example.com/villa10.jpg",
                            ImageUrl = "",
                            Name = "Forest Retreat",
                            Occupancy = 6,
                            Rate = 270.0,
                            Sqft = 1900,
                            UpdatedDate = new DateTime(2024, 6, 27, 2, 13, 41, 180, DateTimeKind.Local).AddTicks(2389)
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MagicVilla_VillaAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MagicVilla_VillaAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MagicVilla_VillaAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MagicVilla_VillaAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}