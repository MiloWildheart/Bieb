﻿// <auto-generated />
using Bieb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bieb.Migrations
{
    [DbContext(typeof(BiebDbContext))]
    [Migration("20230615130650_SeedData3")]
    partial class SeedData3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthorBiebItem", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<int>("BiebItemsId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsId", "BiebItemsId");

                    b.HasIndex("BiebItemsId");

                    b.ToTable("AuthorBiebItem");
                });

            modelBuilder.Entity("Bieb.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ron"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Polina"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tom"
                        });
                });

            modelBuilder.Entity("Bieb.Models.BiebItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MediaType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BiebItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MediaType = "Book",
                            Titel = "WPF is depricated"
                        },
                        new
                        {
                            Id = 2,
                            MediaType = "Book",
                            Titel = "How do i seed this correctly for dummies"
                        },
                        new
                        {
                            Id = 3,
                            MediaType = "Book",
                            Titel = "WPF is depricated a sequel"
                        });
                });

            modelBuilder.Entity("AuthorBiebItem", b =>
                {
                    b.HasOne("Bieb.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bieb.Models.BiebItem", null)
                        .WithMany()
                        .HasForeignKey("BiebItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
