﻿// <auto-generated />
using System;
using CheckoutSystem.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CheckoutSystem.Migrations
{
    [DbContext(typeof(CheckoutSystemDbContext))]
    partial class CheckoutSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CheckoutSystem.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerType")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerType = 0,
                            Email = "martin@gmail.com",
                            LastName = "Lucena",
                            Name = "Martin"
                        },
                        new
                        {
                            Id = 2,
                            CustomerType = 1,
                            Email = "malin@gmail.com",
                            LastName = "Andersson",
                            Name = "Malin"
                        });
                });

            modelBuilder.Entity("CheckoutSystem.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("FilmMediaType")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Films");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            FilmMediaType = 0,
                            Price = 29,
                            Titel = "Titanic"
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 1,
                            FilmMediaType = 1,
                            Price = 39,
                            Titel = "The Shawshank Redemption"
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 2,
                            FilmMediaType = 0,
                            Price = 29,
                            Titel = "The Godfather"
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 2,
                            FilmMediaType = 1,
                            Price = 39,
                            Titel = "Pulp Fiction"
                        },
                        new
                        {
                            Id = 5,
                            FilmMediaType = 0,
                            Price = 29,
                            Titel = "The Dark Knight"
                        },
                        new
                        {
                            Id = 6,
                            FilmMediaType = 1,
                            Price = 39,
                            Titel = "Forrest Gump"
                        },
                        new
                        {
                            Id = 7,
                            FilmMediaType = 0,
                            Price = 29,
                            Titel = "The Matrix"
                        },
                        new
                        {
                            Id = 8,
                            FilmMediaType = 1,
                            Price = 39,
                            Titel = "Schindler's List"
                        },
                        new
                        {
                            Id = 9,
                            FilmMediaType = 0,
                            Price = 29,
                            Titel = "The Silence of the Lambs"
                        },
                        new
                        {
                            Id = 10,
                            FilmMediaType = 1,
                            Price = 39,
                            Titel = "Fight Club"
                        },
                        new
                        {
                            Id = 11,
                            FilmMediaType = 0,
                            Price = 29,
                            Titel = "Gladiator"
                        },
                        new
                        {
                            Id = 12,
                            FilmMediaType = 1,
                            Price = 39,
                            Titel = "The Lord of the Rings: The Fellowship of the Ring"
                        },
                        new
                        {
                            Id = 13,
                            FilmMediaType = 0,
                            Price = 29,
                            Titel = "Star Wars: Episode IV - A New Hope"
                        },
                        new
                        {
                            Id = 14,
                            FilmMediaType = 1,
                            Price = 39,
                            Titel = "Inception"
                        },
                        new
                        {
                            Id = 15,
                            FilmMediaType = 0,
                            Price = 29,
                            Titel = "Interstellar"
                        });
                });

            modelBuilder.Entity("CheckoutSystem.Models.Film", b =>
                {
                    b.HasOne("CheckoutSystem.Models.Customer", "Customer")
                        .WithMany("Films")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CheckoutSystem.Models.Customer", b =>
                {
                    b.Navigation("Films");
                });
#pragma warning restore 612, 618
        }
    }
}