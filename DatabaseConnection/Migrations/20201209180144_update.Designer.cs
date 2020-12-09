﻿// <auto-generated />
using System;
using DatabaseConnection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatabaseConnection.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201209180144_update")]
    partial class update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("DatabaseConnection.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Användarnamn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lösenord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mailaddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postaddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefonnummer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DatabaseConnection.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("DatabaseConnection.LeadingActor", b =>
                {
                    b.Property<int>("LeadingActorid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("First_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LeadingActorid");

                    b.ToTable("LeadingActors");
                });

            modelBuilder.Entity("DatabaseConnection.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Bild")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Filmtitel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("DatabaseConnection.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("MovieId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("GenresId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("GenreMovie");
                });

            modelBuilder.Entity("LeadingActorMovie", b =>
                {
                    b.Property<int>("LeadingActorsLeadingActorid")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("LeadingActorsLeadingActorid", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("LeadingActorMovie");
                });

            modelBuilder.Entity("DatabaseConnection.Rental", b =>
                {
                    b.HasOne("DatabaseConnection.Customer", "Customer")
                        .WithMany("Rentals")
                        .HasForeignKey("CustomerId");

                    b.HasOne("DatabaseConnection.Movie", "Movie")
                        .WithMany("Rentals")
                        .HasForeignKey("MovieId");

                    b.Navigation("Customer");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("DatabaseConnection.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseConnection.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LeadingActorMovie", b =>
                {
                    b.HasOne("DatabaseConnection.LeadingActor", null)
                        .WithMany()
                        .HasForeignKey("LeadingActorsLeadingActorid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseConnection.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DatabaseConnection.Customer", b =>
                {
                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("DatabaseConnection.Movie", b =>
                {
                    b.Navigation("Rentals");
                });
#pragma warning restore 612, 618
        }
    }
}
