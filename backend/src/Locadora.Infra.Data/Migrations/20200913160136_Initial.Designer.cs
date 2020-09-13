﻿// <auto-generated />
using System;
using Locadora.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Locadora.Infra.Data.Migrations
{
    [DbContext(typeof(RentalContext))]
    [Migration("20200913160136_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Locadora.Domain.Features.Customers.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(14)")
                        .HasMaxLength(14);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf = "012.345.678-90",
                            Name = "Leonardo"
                        });
                });

            modelBuilder.Entity("Locadora.Domain.Features.Genres.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CreationDate = new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ação"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CreationDate = new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ficção"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CreationDate = new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Comédia"
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            CreationDate = new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 5,
                            Active = true,
                            CreationDate = new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Terror"
                        });
                });

            modelBuilder.Entity("Locadora.Domain.Features.RentMovies.RentMovie", b =>
                {
                    b.Property<int>("RentId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("RentId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("RentMovies");
                });

            modelBuilder.Entity("Locadora.Domain.Features.Rents.Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("Locadora.Domain.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CreationDate = new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 1,
                            Name = "Vingadores"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CreationDate = new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 1,
                            Name = "Homem-Aranha"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CreationDate = new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenreId = 1,
                            Name = "Homem de Ferro"
                        });
                });

            modelBuilder.Entity("Locadora.Domain.Features.RentMovies.RentMovie", b =>
                {
                    b.HasOne("Locadora.Domain.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Locadora.Domain.Features.Rents.Rent", "Rent")
                        .WithMany("RentMovies")
                        .HasForeignKey("RentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Locadora.Domain.Features.Rents.Rent", b =>
                {
                    b.HasOne("Locadora.Domain.Features.Customers.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Locadora.Domain.Movie", b =>
                {
                    b.HasOne("Locadora.Domain.Features.Genres.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}